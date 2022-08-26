using System.Collections.Generic;

namespace CustomMiniORM
{
    //Entity classes MUST be reference types and instance!
    internal class ChangeTracker<TEntity>
    where TEntity : class, new()
    {
        //Load all entities available
        private readonly List<TEntity> allEntities;

        //Added,but not saved
        private readonly List<TEntity> added;

        //Removed, but still not saved
        private readonly List<TEntity> removed;
    }
}