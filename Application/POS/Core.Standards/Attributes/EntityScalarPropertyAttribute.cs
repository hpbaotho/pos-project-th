using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Standards.Attributes
{
    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = true)]
    public class EntityScalarPropertyAttribute : Attribute
    {
        public bool EntityKey { get; set; }
        public bool Nullable { get; set; }
        public bool IdentityKey { get; set; }
        public bool GuidKey { get; set; }
        public bool PersistenceIgnorance { get; set; }
        private bool insert = true;
        /// <summary>
        /// Enable insert on this property
        ///	- Default value is true
        /// </summary>
        public bool Insert
        {
            get { return this.insert; }
            set { this.insert = value; }
        }
        private bool update = true;
        /// <summary>
        /// Enable update on this property
        ///	- Default value is true
        /// </summary>
        public bool Update
        {
            get { return this.update; }
            set { this.update = value; }
        }

        public string ReplaceNullBy { get; set; }
        public string ExpressionSQL { get; set; }

        /*======= Property UpdateBy,UpdateDate */
        public bool ObjIsUpdateBy { get; set; }
        public bool ObjIsUpdateDate { get; set; }
        public bool ObjMapUpdateBy { get; set; }
        public bool ObjMapUpdateDate { get; set; }
    }
    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = true)]
    public class FOREIGNObject : Attribute
    {

        public string PARENTKEY { get; set; }
        public string EntieTypeName { get; set; }
    }
}
