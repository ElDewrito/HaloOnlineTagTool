using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaloOnlineTagTool.Resources.Geometry
{
    public static class VertexStreamFactory
    {
        /// <summary>
        /// Creates a vertex stream for a given engine version.
        /// </summary>
        /// <param name="version">The engine version.</param>
        /// <param name="stream">The base stream.</param>
        /// <returns>The created vertex stream.</returns>
        public static IVertexStream Create(EngineVersion version, Stream stream)
        {
            if (VersionDetection.Compare(version, EngineVersion.V1_235640_cert_ms25) >= 0)
                return new V1_235640.VertexStream(stream);
            return new V1_106708.VertexStream(stream);
        }
    }
}
