using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaloOnlineTagTool
{
    public static class StringIdResolverFactory
    {
        /// <summary>
        /// Creates a stringID resolver for a given engine version.
        /// </summary>
        /// <param name="version">The version.</param>
        /// <returns>The resolver.</returns>
        public static StringIdResolverBase Create(EngineVersion version)
        {
            if (VersionDetection.Compare(version, EngineVersion.V12_1_700123_cert_ms30_oct19) >= 0)
                return new V12_1_700123.StringIdResolver();
            if (VersionDetection.Compare(version, EngineVersion.V11_1_498295_Live) >= 0)
                return new V11_1_498295.StringIdResolver();
            return new V1_106708.StringIdResolver();
        }
    }
}
