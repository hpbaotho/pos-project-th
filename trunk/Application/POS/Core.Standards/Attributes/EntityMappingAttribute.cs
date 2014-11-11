using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Standards.Attributes
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    public class EntityMappingAttribute : Attribute
    {
        public string TableMapping { get; set; }
        public string EntityTypeName { get; set; }
    }
}
