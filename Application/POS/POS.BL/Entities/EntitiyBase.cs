using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Standards.Attributes;
using System.Reflection;

namespace POS.BL.Entities
{
    public abstract class EntityBase : Core.Standards.Entity.EntityBase
    {
        private string createdBy = string.Empty;

        [EntityScalarProperty(Update = false)]
        public string created_by
        {
            get { return this.createdBy; }
            set { this.createdBy = value; }
        }

        private DateTime createdDate = DateTime.Now;
        [EntityScalarProperty(Update = false)]
        public DateTime created_date
        {
            get { return this.createdDate; }
            set { this.createdDate = value; }
        }

        private string updatedBy = string.Empty;
        [EntityScalarPropertyAttribute(ObjMapUpdateBy = true)]
        public virtual string updated_by
        {
            get { return this.updatedBy; }
            set { this.updatedBy = value; }
        }

        private DateTime updatedDate = DateTime.Now;
        [EntityScalarPropertyAttribute(ObjMapUpdateDate = true)]
        public virtual DateTime updated_date
        {
            get { return this.updatedDate; }
            set { this.updatedDate = value; }
        }

        private DateTime updateDateEntity = DateTime.Now;
        [EntityScalarPropertyAttribute(PersistenceIgnorance = true, ObjIsUpdateDate = true)]
        public DateTime UpdateDateEntity
        {
            get { return this.updateDateEntity; }
            set { this.updateDateEntity = value; }
        }

        private string updateByEntity = string.Empty;
        [EntityScalarPropertyAttribute(PersistenceIgnorance = true, ObjIsUpdateBy = true)]
        public string UpdateByEntity
        {
            get { return this.updateByEntity; }
            set { this.updateByEntity = value; }

        }

        public EntityBase()
        {
            this.created_by = "SYSTEM";
            this.updated_by = "SYSTEM";
            this.UpdateByEntity = "SYSTEM";

        }
        public Type[] GetTypesInNamespace()
        {
            Type[] allNamespace = Assembly.GetExecutingAssembly().GetTypes();
            return Assembly.GetExecutingAssembly().GetTypes().Where(t => t.Namespace.Equals("POS.BL.Entities.Entity")).ToArray();
        }
    }
}
