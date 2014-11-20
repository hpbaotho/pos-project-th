using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Standards.Attributes;
using System.Reflection;
using Core.Standards.Exceptions;

namespace Core.Standards.Entity
{
    public abstract class EntityBase
	{
		internal virtual string TableName
		{
			get 
			{
				if (this.GetType().IsTaggedWithAttribute<EntityMappingAttribute>(true))
				{
					return this.GetType().GetCustomAttribute<EntityMappingAttribute>(true).TableMapping;
				}
				else
				{
					throw new ValidationException();
				}
			}
		}
		internal virtual IList<PropertyInfo> KeyProperties
		{
			get
			{
				return this.GetType().GetTaggedPropertyInfos<EntityScalarPropertyAttribute>("EntityKeyProperty", true, true);
			}
		}
		internal virtual IList<PropertyInfo> IdentityKeyProperties
		{
			get
			{
				return this.GetType().GetTaggedPropertyInfos<EntityScalarPropertyAttribute>("IdentityKey", true, true);
			}
		}
		internal virtual IList<PropertyInfo> PersistenceIgnoranceProperties
		{
			get 
			{
				return this.GetType().GetTaggedPropertyInfos<EntityScalarPropertyAttribute>("PersistenceIgnoranceProperty", true, true);
			}
		}
		internal virtual IList<PropertyInfo> IgnoreInsertProperties
		{
			get
			{
				return this.GetType().GetTaggedPropertyInfos<EntityScalarPropertyAttribute>("Insert", false, true);
			}
		}
		internal virtual IList<PropertyInfo> IgnoreUpdateProperties
		{
			get
			{
				return this.GetType().GetTaggedPropertyInfos<EntityScalarPropertyAttribute>("Update", false, true);
			}
		}
    }
}
