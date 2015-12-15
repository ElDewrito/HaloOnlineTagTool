using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HaloOnlineTagTool.Common;
using HaloOnlineTagTool.Resources;
using HaloOnlineTagTool.Serialization;

namespace HaloOnlineTagTool.TagStructures
{
    [TagStructure(Name = "sandbox_text_value_pair_definition", Class = "jmrq", Size = 0xC)]
    public class SandboxTextValuePairDefinition
    {
        public List<SandboxTextValuePair> SandboxTextValuePairs;

        [TagStructure(Size = 0x10)]
        public class SandboxTextValuePair
        {
            public StringId ParameterName;
            public List<TextValuePari> TextValueParis;

            [TagStructure(Size = 0x14)]
            public class TextValuePari
            {
                public byte Flags;
                public ExpectedValueTypeValue ExpectedValueType;
                public short Unknown;
                public int IntValue;
                public StringId RefName;
                public StringId Name;
                public StringId Description;

                public enum ExpectedValueTypeValue : sbyte
                {
                    IntegerIndex,
                    StringidReference,
                    Incremental,
                }
            }
        }
    }
}
