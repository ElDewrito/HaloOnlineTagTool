using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaloOnlineTagTool.Serialization
{
    /// <summary>
    /// Attribute indicating the last engine version in which a tag element is present.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class MaxVersionAttribute : Attribute
    {
        public MaxVersionAttribute(EngineVersion version)
        {
            Version = version;
        }

        public EngineVersion Version { get; set; }
    }
}
