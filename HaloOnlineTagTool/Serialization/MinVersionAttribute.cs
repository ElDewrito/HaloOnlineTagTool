using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaloOnlineTagTool.Serialization
{
    /// <summary>
    /// Attribute indicating the first engine version in which a tag element is present.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class MinVersionAttribute : Attribute
    {
        public MinVersionAttribute(EngineVersion version)
        {
            Version = version;
        }

        public EngineVersion Version { get; set; }
    }
}
