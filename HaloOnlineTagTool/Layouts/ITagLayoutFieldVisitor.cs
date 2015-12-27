using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaloOnlineTagTool.Layouts
{
    /// <summary>
    /// Interface for a tag layout field visitor.
    /// </summary>
    public interface ITagLayoutFieldVisitor
    {
        void Visit(BasicTagLayoutField field);
        void Visit(ArrayTagLayoutField field);
        void Visit(EnumTagLayoutField field);
        void Visit(StringTagLayoutField field);
        void Visit(TagBlockTagLayoutField field);
    }
}
