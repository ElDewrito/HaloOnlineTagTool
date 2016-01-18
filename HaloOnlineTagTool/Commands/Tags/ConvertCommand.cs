using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using HaloOnlineTagTool.Common;
using HaloOnlineTagTool.Resources;
using HaloOnlineTagTool.Resources.Geometry;
using HaloOnlineTagTool.Resources.Shaders;
using HaloOnlineTagTool.Serialization;
using HaloOnlineTagTool.TagStructures;

namespace HaloOnlineTagTool.Commands.Tags
{
    class ConvertCommand : Command
    {
        private readonly OpenTagCache _info;
        private bool _isDecalShader = false;

        public ConvertCommand(OpenTagCache info) : base(
            CommandFlags.None,

            "convert",
            "Convert a tag and its dependencies to another engine version",

            "convert <tag index> <tag map csv> <output csv> <target directory>",

            "The tag map CSV should be generated using the \"matchtags\" command.\n" +
            "If a tag is listed in the CSV file, it will not be converted.\n" +
            "The output CSV file is used for converting multiple maps.\n" +
            "Subsequent convert commands should use the new CSV.\n" +
            "The target directory should be the maps folder for the target engine.")
        {
            _info = info;
        }

        public override bool Execute(List<string> args)
        {
            if (args.Count != 4)
                return false;
            var srcTag = ArgumentParser.ParseTagIndex(_info.Cache, args[0]);
            if (srcTag == null)
                return false;
            var csvPath = args[1];
            var csvOutPath = args[2];
            var targetDir = args[3];

            // Load the CSV
            Console.WriteLine("Reading {0}...", csvPath);
            TagVersionMap tagMap;
            using (var reader = new StreamReader(File.OpenRead(csvPath)))
                tagMap = TagVersionMap.ParseCsv(reader);

            // Load destination files
            Console.WriteLine("Loading the target tags.dat...");
            var destCachePath = Path.Combine(targetDir, "tags.dat");
            var destInfo = new OpenTagCache { CacheFile = new FileInfo(destCachePath) };
            using (var stream = destInfo.OpenCacheRead())
                destInfo.Cache = new TagCache(stream);

            // Do version detection
            EngineVersion guessedVersion;
            destInfo.Version = VersionDetection.DetectVersion(destInfo.Cache, out guessedVersion);
            if (destInfo.Version == EngineVersion.Unknown)
            {
                Console.WriteLine("Unrecognized target version!");
                return true;
            }
            Console.WriteLine("- Detected version {0}", VersionDetection.GetVersionString(destInfo.Version));

            if (_info.Version != EngineVersion.V11_1_498295_Live && destInfo.Version != EngineVersion.V1_106708_cert_ms23)
            {
                Console.Error.WriteLine("Conversion is only supported from 11.1.498295 Live to 1.106708 cert_ms23.");
                return true;
            }

            // Set up version-specific objects
            destInfo.Serializer = new TagSerializer(destInfo.Version);
            destInfo.Deserializer = new TagDeserializer(destInfo.Version);
            StringIdResolverBase resolver;
            if (VersionDetection.Compare(destInfo.Version, EngineVersion.V11_1_498295_Live) >= 0)
                resolver = new V11_1_498295.StringIdResolver();
            else
                resolver = new V1_106708.StringIdResolver();

            // Load stringIDs
            Console.WriteLine("Loading the target string_ids.dat...");
            var destStringIdsPath = Path.Combine(targetDir, "string_ids.dat");
            destInfo.StringIdsFile = new FileInfo(destStringIdsPath);
            using (var stream = destInfo.StringIdsFile.OpenRead())
                destInfo.StringIds = new StringIdCache(stream, resolver);

            // Load resources for the target build
            Console.WriteLine("Loading target resources...");
            var destResources = new ResourceDataManager();
            destResources.LoadCachesFromDirectory(destInfo.CacheFile.DirectoryName);

            // Load resources for our build
            Console.WriteLine("Loading source resources...");
            var srcResources = new ResourceDataManager();
            srcResources.LoadCachesFromDirectory(_info.CacheFile.DirectoryName);

            Console.WriteLine();
            Console.WriteLine("CONVERTING FROM VERSION {0} TO {1}", VersionDetection.GetVersionString(_info.Version), VersionDetection.GetVersionString(destInfo.Version));
            Console.WriteLine();

            TagInstance resultTag;
            using (Stream srcStream = _info.OpenCacheRead(), destStream = destInfo.OpenCacheReadWrite())
                resultTag = ConvertTag(srcTag, _info, srcStream, srcResources, destInfo, destStream, destResources, tagMap);

            Console.WriteLine();
            Console.WriteLine("Repairing decal systems...");
            FixDecalSystems(destInfo, resultTag.Index);

            Console.WriteLine();
            Console.WriteLine("Saving stringIDs...");
            using (var stream = destInfo.StringIdsFile.Open(FileMode.Open, FileAccess.ReadWrite))
                destInfo.StringIds.Save(stream);

            Console.WriteLine("Writing {0}...", csvOutPath);
            using (var stream = new StreamWriter(File.Open(csvOutPath, FileMode.Create, FileAccess.ReadWrite)))
                tagMap.WriteCsv(stream);

            // Uncomment this to add the new tag as a dependency to cfgt to make testing easier
            /*using (var stream = destInfo.OpenCacheReadWrite())
            {
                destInfo.Cache.Tags[0].Dependencies.Add(resultTag.Index);
                destInfo.Cache.UpdateTag(stream, destInfo.Cache.Tags[0]);
            }*/

            Console.WriteLine();
            Console.WriteLine("All done! The converted tag is:");
            TagPrinter.PrintTagShort(resultTag);
            return true;
        }

        private TagInstance ConvertTag(TagInstance srcTag, OpenTagCache srcInfo, Stream srcStream, ResourceDataManager srcResources, OpenTagCache destInfo, Stream destStream, ResourceDataManager destResources, TagVersionMap tagMap)
        {
            TagPrinter.PrintTagShort(srcTag);

            // Uncomment this to use 0x101F for all shaders
            /*if (srcTag.IsClass("rm  "))
                return destInfo.Cache.Tags[0x101F];*/

            // Check if the tag is in the map, and just return the translated tag if so
            var destIndex = tagMap.Translate(srcInfo.Version, srcTag.Index, destInfo.Version);
            if (destIndex >= 0)
            {
                Console.WriteLine("- Using already-known index {0:X4}", destIndex);
                return destInfo.Cache.Tags[destIndex];
            }

            // Deserialize the tag from the source cache
            var structureType = TagStructureTypes.FindByGroupTag(srcTag.Group.Tag);
            var srcContext = new TagSerializationContext(srcStream, srcInfo.Cache, srcInfo.StringIds, srcTag);
            var tagData = srcInfo.Deserializer.Deserialize(srcContext, structureType);

            // Uncomment this to use 0x101F in place of shaders that need conversion
            /*if (tagData is RenderMethod)
            {
                var rm = (RenderMethod)tagData;
                foreach (var prop in rm.ShaderProperties)
                {
                    if (tagMap.Translate(srcInfo.Version, prop.Template.Index, destInfo.Version) < 0)
                        return destInfo.Cache.Tags[0x101F];
                }
            }*/

            // Allocate a new tag and create a mapping for it
            var newTag = destInfo.Cache.AllocateTag(srcTag.Group);
            tagMap.Add(srcInfo.Version, srcTag.Index, destInfo.Version, newTag.Index);

            if (srcTag.IsInGroup("decs") || srcTag.IsInGroup("rmd "))
                _isDecalShader = true;

            // Convert it
            tagData = Convert(tagData, srcInfo, srcStream, srcResources, destInfo, destStream, destResources, tagMap);

            if (srcTag.IsInGroup("decs") || srcTag.IsInGroup("rmd "))
                _isDecalShader = false;

            // Re-serialize into the destination cache
            var destContext = new TagSerializationContext(destStream, destInfo.Cache, destInfo.StringIds, newTag);
            destInfo.Serializer.Serialize(destContext, tagData);
            return newTag;
        }

        private object Convert(object data, OpenTagCache srcInfo, Stream srcStream, ResourceDataManager srcResources, OpenTagCache destInfo, Stream destStream, ResourceDataManager destResources, TagVersionMap tagMap)
        {
            if (data == null)
                return null;
            var type = data.GetType();
            if (type.IsPrimitive)
                return data;
            if (type == typeof(StringId))
                return ConvertStringId((StringId)data, srcInfo, destInfo);
            if (type == typeof(TagInstance))
                return ConvertTag((TagInstance)data, srcInfo, srcStream, srcResources, destInfo, destStream, destResources, tagMap);
            if (type == typeof(ResourceReference))
                return ConvertResource((ResourceReference)data, srcInfo, srcResources, destInfo, destResources);
            if (type == typeof(GeometryReference))
                return ConvertGeometry((GeometryReference)data, srcInfo, srcResources, destInfo, destResources);
            if (type.IsArray)
                return ConvertArray((Array)data, srcInfo, srcStream, srcResources, destInfo, destStream, destResources, tagMap);
            if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(List<>))
                return ConvertList(data, type, srcInfo, srcStream, srcResources, destInfo, destStream, destResources, tagMap);
            if (type.GetCustomAttributes(typeof(TagStructureAttribute), false).Length > 0)
                return ConvertStructure(data, type, srcInfo, srcStream, srcResources, destInfo, destStream, destResources, tagMap);
            return data;
        }

        private Array ConvertArray(Array array, OpenTagCache srcInfo, Stream srcStream, ResourceDataManager srcResources, OpenTagCache destInfo, Stream destStream, ResourceDataManager destResources, TagVersionMap tagMap)
        {
            if (array.GetType().GetElementType().IsPrimitive)
                return array;
            for (var i = 0; i < array.Length; i++)
            {
                var oldValue = array.GetValue(i);
                var newValue = Convert(oldValue, srcInfo, srcStream, srcResources, destInfo, destStream, destResources, tagMap);
                array.SetValue(newValue, i);
            }
            return array;
        }

        private object ConvertList(object list, Type type, OpenTagCache srcInfo, Stream srcStream, ResourceDataManager srcResources, OpenTagCache destInfo, Stream destStream, ResourceDataManager destResources, TagVersionMap tagMap)
        {
            if (type.GenericTypeArguments[0].IsPrimitive)
                return list;
            var count = (int)type.GetProperty("Count").GetValue(list);
            var getItem = type.GetMethod("get_Item");
            var setItem = type.GetMethod("set_Item");
            for (var i = 0; i < count; i++)
            {
                var oldValue = getItem.Invoke(list, new object[] { i });
                var newValue = Convert(oldValue, srcInfo, srcStream, srcResources, destInfo, destStream, destResources, tagMap);
                setItem.Invoke(list, new object[] { i, newValue });
            }
            return list;
        }

        private object ConvertStructure(object data, Type type, OpenTagCache srcInfo, Stream srcStream, ResourceDataManager srcResources, OpenTagCache destInfo, Stream destStream, ResourceDataManager destResources, TagVersionMap tagMap)
        {
            // Convert each field
            var enumerator = new TagFieldEnumerator(new TagStructureInfo(type, destInfo.Version));
            while (enumerator.Next())
            {
                var oldValue = enumerator.Field.GetValue(data);
                var newValue = Convert(oldValue, srcInfo, srcStream, srcResources, destInfo, destStream, destResources, tagMap);
                enumerator.Field.SetValue(data, newValue);
            }

            // Perform fixups
            FixObjectTypes(data, type, srcInfo);
            FixShaders(data);
            var scenario = data as Scenario;
            if (scenario != null)
                FixScenario(scenario);

            return data;
        }

        private StringId ConvertStringId(StringId stringId, OpenTagCache srcInfo, OpenTagCache destInfo)
        {
            if (stringId == StringId.Null)
                return stringId;
            var srcString = srcInfo.StringIds.GetString(stringId);
            if (srcString == null)
                return StringId.Null;
            var destStringId = destInfo.StringIds.GetStringId(srcString);
            if (destStringId == StringId.Null)
                destStringId = destInfo.StringIds.Add(srcString);
            return destStringId;
        }

        private ResourceReference ConvertResource(ResourceReference resource, OpenTagCache srcInfo, ResourceDataManager srcResources, OpenTagCache destInfo, ResourceDataManager destResources)
        {
            if (resource == null)
                return null;
            Console.WriteLine("- Copying resource {0} in {1}...", resource.Index, resource.GetLocation());
            var data = srcResources.ExtractRaw(resource);
            var newLocation = FixResourceLocation(resource.GetLocation(), srcInfo.Version, destInfo.Version);
            destResources.AddRaw(resource, newLocation, data);
            return resource;
        }

        private ResourceLocation FixResourceLocation(ResourceLocation location, EngineVersion srcVersion, EngineVersion destVersion)
        {
            if (VersionDetection.Compare(destVersion, EngineVersion.V1_235640_cert_ms25) >= 0)
                return location;
            switch (location)
            {
                case ResourceLocation.RenderModels:
                    return ResourceLocation.Resources;
                case ResourceLocation.Lightmaps:
                    return ResourceLocation.Textures;
            }
            return location;
        }

        private GeometryReference ConvertGeometry(GeometryReference geometry, OpenTagCache srcInfo, ResourceDataManager srcResources, OpenTagCache destInfo, ResourceDataManager destResources)
        {
            if (geometry == null || geometry.Resource == null || geometry.Resource.Index < 0)
                return geometry;

            // The format changed starting with version 1.235640, so if both versions are on the same side then they can be converted normally
            var srcCompare = VersionDetection.Compare(srcInfo.Version, EngineVersion.V1_235640_cert_ms25);
            var destCompare = VersionDetection.Compare(destInfo.Version, EngineVersion.V1_235640_cert_ms25);
            if ((srcCompare < 0 && destCompare < 0) || (srcCompare >= 0 && destCompare >= 0))
            {
                geometry.Resource = ConvertResource(geometry.Resource, srcInfo, srcResources, destInfo, destResources);
                return geometry;
            }

            Console.WriteLine("- Rebuilding geometry resource {0} in {1}...", geometry.Resource.Index, geometry.Resource.GetLocation());
            using (MemoryStream inStream = new MemoryStream(), outStream = new MemoryStream())
            {
                // First extract the model data
                srcResources.Extract(geometry.Resource, inStream);

                // Now open source and destination vertex streams
                inStream.Position = 0;
                var inVertexStream = VertexStreamFactory.Create(srcInfo.Version, inStream);
                var outVertexStream = VertexStreamFactory.Create(destInfo.Version, outStream);

                // Deserialize the definition data
                var resourceContext = new ResourceSerializationContext(geometry.Resource);
                var definition = srcInfo.Deserializer.Deserialize<RenderGeometryResourceDefinition>(resourceContext);

                // Convert each vertex buffer
                foreach (var buffer in definition.VertexBuffers)
                    ConvertVertexBuffer(buffer.Definition, inStream, inVertexStream, outStream, outVertexStream);

                // Copy each index buffer over
                foreach (var buffer in definition.IndexBuffers)
                {
                    if (buffer.Definition.Data.Size == 0)
                        continue;
                    inStream.Position = buffer.Definition.Data.Address.Offset;
                    buffer.Definition.Data.Address = new ResourceAddress(ResourceAddressType.Resource, (int)outStream.Position);
                    var bufferData = new byte[buffer.Definition.Data.Size];
                    inStream.Read(bufferData, 0, bufferData.Length);
                    outStream.Write(bufferData, 0, bufferData.Length);
                    StreamUtil.Align(outStream, 4);
                }

                // Update the definition data
                destInfo.Serializer.Serialize(resourceContext, definition);

                // Now inject the new resource data
                var newLocation = FixResourceLocation(geometry.Resource.GetLocation(), srcInfo.Version, destInfo.Version);
                outStream.Position = 0;
                destResources.Add(geometry.Resource, newLocation, outStream);
            }
            return geometry;
        }

        private void ConvertVertexBuffer(VertexBufferDefinition buffer, MemoryStream inStream, IVertexStream inVertexStream, MemoryStream outStream, IVertexStream outVertexStream)
        {
            if (buffer.Data.Size == 0)
                return;
            var count = buffer.Count;
            var startPos = (int)outStream.Position;
            inStream.Position = buffer.Data.Address.Offset;
            buffer.Data.Address = new ResourceAddress(ResourceAddressType.Resource, startPos);
            switch (buffer.Format)
            {
                case VertexBufferFormat.World:
                    ConvertVertices(count, inVertexStream.ReadWorldVertex, v =>
                    {
                        v.Binormal = new Vector3(v.Position.W, v.Tangent.W, 0); // Converted shaders use this
                        outVertexStream.WriteWorldVertex(v);
                    });
                    break;
                case VertexBufferFormat.Rigid:
                    ConvertVertices(count, inVertexStream.ReadRigidVertex, v =>
                    {
                        v.Binormal = new Vector3(v.Position.W, v.Tangent.W, 0); // Converted shaders use this
                        outVertexStream.WriteRigidVertex(v);
                    });
                    break;
                case VertexBufferFormat.Skinned:
                    ConvertVertices(count, inVertexStream.ReadSkinnedVertex, v =>
                    {
                        v.Binormal = new Vector3(v.Position.W, v.Tangent.W, 0); // Converted shaders use this
                        outVertexStream.WriteSkinnedVertex(v);
                    });
                    break;
                case VertexBufferFormat.StaticPerPixel:
                    ConvertVertices(count, inVertexStream.ReadStaticPerPixelData, outVertexStream.WriteStaticPerPixelData);
                    break;
                case VertexBufferFormat.StaticPerVertex:
                    ConvertVertices(count, inVertexStream.ReadStaticPerVertexData, outVertexStream.WriteStaticPerVertexData);
                    break;
                case VertexBufferFormat.AmbientPrt:
                    ConvertVertices(count, inVertexStream.ReadAmbientPrtData, outVertexStream.WriteAmbientPrtData);
                    break;
                case VertexBufferFormat.LinearPrt:
                    ConvertVertices(count, inVertexStream.ReadLinearPrtData, outVertexStream.WriteLinearPrtData);
                    break;
                case VertexBufferFormat.QuadraticPrt:
                    ConvertVertices(count, inVertexStream.ReadQuadraticPrtData, outVertexStream.WriteQuadraticPrtData);
                    break;
                case VertexBufferFormat.StaticPerVertexColor:
                    ConvertVertices(count, inVertexStream.ReadStaticPerVertexColorData, outVertexStream.WriteStaticPerVertexColorData);
                    break;
                case VertexBufferFormat.Decorator:
                    ConvertVertices(count, inVertexStream.ReadDecoratorVertex, outVertexStream.WriteDecoratorVertex);
                    break;
                case VertexBufferFormat.World2:
                    buffer.Format = VertexBufferFormat.World;
                    goto default;
                default:
                    // Just copy the raw buffer over and pray that it works...
                    var bufferData = new byte[buffer.Data.Size];
                    inStream.Read(bufferData, 0, bufferData.Length);
                    outStream.Write(bufferData, 0, bufferData.Length);
                    break;
            }
            buffer.Data.Size = (int)outStream.Position - startPos;
            buffer.VertexSize = (short)(buffer.Data.Size / buffer.Count);
        }

        private void ConvertVertices<T>(int count, Func<T> readFunc, Action<T> writeFunc)
        {
            for (var i = 0; i < count; i++)
                writeFunc(readFunc());
        }

        private void FixObjectTypes(object data, Type type, OpenTagCache srcInfo)
        {
            // The object type enum changed in 11.1.498295 because a new armor type was added at value 3.
            // These are a bunch of hacks to fix this in most cases.
            var oldObjectTypeField = type.GetField("ObjectTypeOld");
            var newObjectTypeField = type.GetField("ObjectTypeNew");
            if (oldObjectTypeField != null && newObjectTypeField != null)
            {
                if (VersionDetection.Compare(srcInfo.Version, EngineVersion.V11_1_498295_Live) < 0)
                {
                    var oldType = (ObjectTypeValueOld)oldObjectTypeField.GetValue(data);
                    newObjectTypeField.SetValue(data, ConvertObjectType(oldType));
                }
                else
                {
                    var newType = (ObjectTypeValueNew)newObjectTypeField.GetValue(data);
                    oldObjectTypeField.SetValue(data, ConvertObjectType(newType));
                }
            }
            var phantom = data as PhysicsModel.PhantomType;
            if (phantom != null)
            {
                // Remove the armor bit added at position 8 in flags
                phantom.Flags = (uint)((phantom.Flags & ~0x1FFE00) | ((phantom.Flags & 0x1FFE00) >> 1));
            }
            var chmt = data as ChocolateMountainNew;
            if (chmt != null && chmt.LightingVariables != null && chmt.LightingVariables.Count > 3)
                chmt.LightingVariables.RemoveAt(3); // Remove armor data from chmt
        }

        private void FixScenario(Scenario data)
        {
            FixSandboxMenu(data.SandboxVehicles);
            FixSandboxMenu(data.SandboxWeapons);
            FixSandboxMenu(data.SandboxEquipment);
            FixSandboxMenu(data.SandboxScenery);
            FixSandboxMenu(data.SandboxTeleporters);
            FixSandboxMenu(data.SandboxGoalObjects);
            FixSandboxMenu(data.SandboxSpawning);
            FixScripts(data);
        }

        private void FixSandboxMenu(List<Scenario.SandboxObject> menu)
        {
            for (var i = 0; i < menu.Count; i++)
            {
                if (menu[i].Object == null || !menu[i].Object.IsInGroup("obje"))
                    menu.RemoveAt(i--);
            }
        }

        private void FixScripts(Scenario data)
        {
            foreach (var expr in data.ScriptExpressions)
            {
                if (expr.ExpressionType == 8 || (expr.ExpressionType == 9 && expr.ValueType == Scenario.ScriptExpression.ValueTypeValue.FunctionName))
                {
                    // Either a function call or a function_name
                    expr.Opcode = FixOpcode(expr.Opcode);
                }
            }
        }

        private ushort FixOpcode(ushort opcode)
        {
            // ZBT -> 1.106708
            // thanks zedd <3
            if (opcode >= 0x685)
                opcode -= 1;
            if (opcode >= 0x5D2)
                opcode += 2;
            if (opcode >= 0x5C6)
                opcode += 3;
            if (opcode >= 0x5AE)
                opcode += 3;
            if (opcode >= 0x527)
                opcode += 4;
            if (opcode >= 0x516)
                opcode += 1;
            if (opcode >= 0x48C)
                opcode += 2;
            if (opcode >= 0x345)
                opcode -= 1;
            if (opcode >= 0x2F2)
                opcode -= 3;
            if (opcode >= 0x15)
                opcode -= 1;
            return opcode;
        }

        private void FixShaders(object data)
        {
            if (_info.Version <= EngineVersion.V1_235640_cert_ms25)
                return;

            var template = data as RenderMethodTemplate;
            if (template != null)
                FixRenderMethodTemplate(template);
            var rmdf = data as RenderMethodDefinition;
            if (rmdf != null)
                FixRenderMethodDefinition(rmdf);
            var glps = data as GlobalPixelShader;
            if (glps != null)
                FixGlobalPixelShader(glps);
            var glvs = data as GlobalVertexShader;
            if (glvs != null)
                FixGlobalVertexShader(glvs);
            var ps = data as PixelShader;
            if (ps != null)
                FixPixelShader(ps);
            var vs = data as VertexShader;
            if (vs != null)
                FixVertexShader(vs);
            var property = data as RenderMethod.ShaderProperty;
            if (property != null)
                FixDrawModeList(property.DrawModes);
        }

        private void FixRenderMethodTemplate(RenderMethodTemplate template)
        {
            FixDrawModeList(template.DrawModes);
            if (template.DrawModes.Count > 18)
                template.DrawModes[18].UnknownBlock2Pointer = 0; // Disable z_only

            // Rebuild the bitmask of valid draw modes
            template.DrawModeBitmask = 0;
            for (var i = 0; i < template.DrawModes.Count; i++)
            {
                if (template.DrawModes[i].UnknownBlock2Pointer != 0)
                    template.DrawModeBitmask |= (uint)(1 << i);
            }
        }

        private void FixRenderMethodDefinition(RenderMethodDefinition definition)
        {
            for (var i = definition.DrawModes.Count - 1; i >= 0; i--)
            {
                var mode = definition.DrawModes[i];
                if (mode.Mode == 2 || mode.Mode == 10 || mode.Mode == 11 || mode.Mode == 12)
                    definition.DrawModes.RemoveAt(i);
                else if (mode.Mode > 12)
                    mode.Mode -= 4;
                else if (mode.Mode > 2)
                    mode.Mode -= 1;
            }
        }

        private void FixGlobalPixelShader(GlobalPixelShader glps)
        {
            FixDrawModeList(glps.DrawModes);
            // glps tags don't appear to need recompilation?
        }

        private void FixGlobalVertexShader(GlobalVertexShader glvs)
        {
            var usedShaders = new bool[glvs.VertexShaders.Count];
            for (var i = 0; i < glvs.VertexTypes.Count; i++)
            {
                FixDrawModeList(glvs.VertexTypes[i].DrawModes);
                if (glvs.VertexTypes[i].DrawModes.Count > 18)
                    glvs.VertexTypes[i].DrawModes[18].ShaderIndex = -1; // Disable z_only
                var type = (VertexType)i;
                for (var j = 0; j < glvs.VertexTypes[i].DrawModes.Count; j++)
                {
                    var mode = glvs.VertexTypes[i].DrawModes[j];
                    if (mode.ShaderIndex < 0)
                        continue;
                    Console.WriteLine("- Recompiling vertex shader {0}...", mode.ShaderIndex);
                    var shader = glvs.VertexShaders[mode.ShaderIndex];
                    var newBytecode = ShaderConverter.ConvertNewVertexShaderToOld(shader.Unknown2, j, type);
                    if (newBytecode != null)
                        shader.Unknown2 = newBytecode;
                    usedShaders[mode.ShaderIndex] = true;
                }
            }

            // Null unused shaders
            for (var i = 0; i < glvs.VertexShaders.Count; i++)
            {
                if (!usedShaders[i])
                    glvs.VertexShaders[i].Unknown2 = null;
            }
        }

        private void FixPixelShader(PixelShader ps)
        {
            FixDrawModeList(ps.DrawModes);

            // Disable z_only
            if (ps.DrawModes.Count > 18)
            {
                ps.DrawModes[18].Index = 0;
                ps.DrawModes[18].Count = 0;
            }

            var usedShaders = new bool[ps.PixelShaders.Count];
            for (var i = 0; i < ps.DrawModes.Count; i++)
            {
                var mode = ps.DrawModes[i];
                for (var j = 0; j < mode.Count; j++)
                {
                    if (i != 0 || _isDecalShader)
                    {
                        Console.WriteLine("- Recompiling pixel shader {0}...", mode.Index + j);
                        var shader = ps.PixelShaders[mode.Index + j];
                        var newBytecode = ShaderConverter.ConvertNewPixelShaderToOld(shader.Unknown2, i);
                        if (newBytecode != null)
                            shader.Unknown2 = newBytecode;
                    }
                    usedShaders[mode.Index + j] = true;
                }
            }

            // Null unused shaders
            for (var i = 0; i < ps.PixelShaders.Count; i++)
            {
                if (!usedShaders[i])
                    ps.PixelShaders[i].Unknown2 = null;
            }
        }

        private void FixVertexShader(VertexShader vs)
        {
            foreach (var unk in vs.Unknown2)
                FixDrawModeList(unk.DrawModes);
            // We don't need to recompile these because vtsh tags will never actually be used in a ported map
        }

        private void FixDrawModeList<T>(IList<T> modes)
        {
            if (modes.Count > 12)
                modes.RemoveAt(12);
            if (modes.Count > 11)
                modes.RemoveAt(11);
            if (modes.Count > 10)
                modes.RemoveAt(10);
            if (modes.Count > 2)
                modes.RemoveAt(2);
        }

        private ObjectTypeValueOld ConvertObjectType(ObjectTypeValueNew type)
        {
            switch (type)
            {
                case ObjectTypeValueNew.None: return ObjectTypeValueOld.None;
                case ObjectTypeValueNew.Biped: return ObjectTypeValueOld.Biped;
                case ObjectTypeValueNew.Vehicle: return ObjectTypeValueOld.Vehicle;
                case ObjectTypeValueNew.Weapon: return ObjectTypeValueOld.Weapon;
                case ObjectTypeValueNew.Equipment: return ObjectTypeValueOld.Equipment;
                case ObjectTypeValueNew.ArgDevice: return ObjectTypeValueOld.ArgDevice;
                case ObjectTypeValueNew.Terminal: return ObjectTypeValueOld.Terminal;
                case ObjectTypeValueNew.Projectile: return ObjectTypeValueOld.Projectile;
                case ObjectTypeValueNew.Scenery: return ObjectTypeValueOld.Scenery;
                case ObjectTypeValueNew.Machine: return ObjectTypeValueOld.Machine;
                case ObjectTypeValueNew.Control: return ObjectTypeValueOld.Control;
                case ObjectTypeValueNew.SoundScenery: return ObjectTypeValueOld.SoundScenery;
                case ObjectTypeValueNew.Crate: return ObjectTypeValueOld.Crate;
                case ObjectTypeValueNew.Creature: return ObjectTypeValueOld.Creature;
                case ObjectTypeValueNew.Giant: return ObjectTypeValueOld.Giant;
                case ObjectTypeValueNew.EffectScenery: return ObjectTypeValueOld.EffectScenery;
                default:
                    throw new NotSupportedException("Unsupported object type: " + type);
            }
        }

        private ObjectTypeValueNew ConvertObjectType(ObjectTypeValueOld type)
        {
            switch (type)
            {
                case ObjectTypeValueOld.None: return ObjectTypeValueNew.None;
                case ObjectTypeValueOld.Biped: return ObjectTypeValueNew.Biped;
                case ObjectTypeValueOld.Vehicle: return ObjectTypeValueNew.Vehicle;
                case ObjectTypeValueOld.Weapon: return ObjectTypeValueNew.Weapon;
                case ObjectTypeValueOld.Equipment: return ObjectTypeValueNew.Equipment;
                case ObjectTypeValueOld.ArgDevice: return ObjectTypeValueNew.ArgDevice;
                case ObjectTypeValueOld.Terminal: return ObjectTypeValueNew.Terminal;
                case ObjectTypeValueOld.Projectile: return ObjectTypeValueNew.Projectile;
                case ObjectTypeValueOld.Scenery: return ObjectTypeValueNew.Scenery;
                case ObjectTypeValueOld.Machine: return ObjectTypeValueNew.Machine;
                case ObjectTypeValueOld.Control: return ObjectTypeValueNew.Control;
                case ObjectTypeValueOld.SoundScenery: return ObjectTypeValueNew.SoundScenery;
                case ObjectTypeValueOld.Crate: return ObjectTypeValueNew.Crate;
                case ObjectTypeValueOld.Creature: return ObjectTypeValueNew.Creature;
                case ObjectTypeValueOld.Giant: return ObjectTypeValueNew.Giant;
                case ObjectTypeValueOld.EffectScenery: return ObjectTypeValueNew.EffectScenery;
                default:
                    throw new NotSupportedException("Unsupported object type: " + type);
            }
        }

        private void FixDecalSystems(OpenTagCache destInfo, int firstNewIndex)
        {
            // decs tags need to be updated to use the old rmdf for decals,
            // because the decal planes seem to be generated by the engine and
            // therefore need to use the old vertex format.
            //
            // This could probably be done as a post-processing step in
            // ConvertStructure to avoid the extra deserialize-reserialize
            // pass, but we'd have to store the rmdf somewhere and frankly I'm
            // too lazy to do that...

            var firstDecalSystemTag = destInfo.Cache.Tags.FindFirstInGroup("decs");
            if (firstDecalSystemTag == null)
                return;
            using (var stream = destInfo.OpenCacheReadWrite())
            {
                var firstDecalSystemContext = new TagSerializationContext(stream, destInfo.Cache, destInfo.StringIds, firstDecalSystemTag);
                var firstDecalSystem = destInfo.Deserializer.Deserialize<DecalSystem>(firstDecalSystemContext);
                foreach (var decalSystemTag in destInfo.Cache.Tags.FindAllInGroup("decs").Where(t => t.Index >= firstNewIndex))
                {
                    TagPrinter.PrintTagShort(decalSystemTag);
                    var context = new TagSerializationContext(stream, destInfo.Cache, destInfo.StringIds, decalSystemTag);
                    var decalSystem = destInfo.Deserializer.Deserialize<DecalSystem>(context);
                    foreach (var system in decalSystem.DecalSystem2)
                        system.BaseRenderMethod = firstDecalSystem.DecalSystem2[0].BaseRenderMethod;
                    destInfo.Serializer.Serialize(context, decalSystem);
                }
            }
        }
    }
}
