using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace CustomMiniORM
{
    //Entity classes MUST be reference types and instance!
    internal class ChangeTracker<TEntity>
    where TEntity : class, new()
    {
        private ChangeTracker()
        {
            this.added = new List<TEntity>();
            this.removed = new List<TEntity>();
        }
        public ChangeTracker(IEnumerable<TEntity> entities)
            :this()
        {
            this.allEntities = CloneEntities(entities);
        }

        public IReadOnlyCollection<TEntity> AllEntities
            =>(IReadOnlyCollection<TEntity>)this.allEntities;

        public IReadOnlyCollection<TEntity> Added
            => (IReadOnlyCollection<TEntity>)this.added;

        public IReadOnlyCollection<TEntity> Read
            => (IReadOnlyCollection<TEntity>)this.removed;

        private IList<TEntity> CloneEntities(IEnumerable<TEntity> entities)
        {
            IList<TEntity> cloneEntities = new List<TEntity>();

            PropertyInfo[] propertiesToClone = typeof(TEntity)
                .GetProperties()
                .Where(P => DbContext.AllowedSQLTypes.Contains(P.PropertyType))
                .ToArray();

            foreach (TEntity originalEntity in entities)
            {
                TEntity clonedEntity = Activator.CreateInstance<TEntity>();

                foreach (PropertyInfo property in propertiesToClone)
                {
                    object originalValue = property.GetValue(originalEntity);
                    property.SetValue(clonedEntity, originalValue);
                }
                cloneEntities.Add(clonedEntity);
            }

            return cloneEntities;
        }
        //Load all entities available
        private readonly IList<TEntity> allEntities;

        //Added,but not saved
        private readonly IList<TEntity> added;

        //Removed, but still not saved
        private readonly IList<TEntity> removed;
    }
}