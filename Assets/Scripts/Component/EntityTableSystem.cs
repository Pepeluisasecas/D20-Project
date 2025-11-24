public interface IEntityTableSystem<T>
{
    CoreDictionary<Entity, T> Table { get; }
    
    void Set(Entity entity, T value);
    T Get(Entity entity);
    bool TryGetValue(Entity entity, out T value);
    bool Has(Entity entity);
    void Remove(Entity entity);
}

public abstract class EntityTableSystem<T> : IEntityTableSystem<T>
{
    public abstract CoreDictionary<Entity, T> Table { get; }

    public virtual void Set(Entity entity, T value)
    {
        Table[entity] = value;
    }

    public virtual T Get(Entity entity)
    {
        T result;
        if (Table.TryGetValue(entity, out result))
            return result;
        return default(T);
    }

    public virtual bool TryGetValue(Entity entity, out T value)
    {
        return Table.TryGetValue(entity, out value);
    }

    public virtual bool Has(Entity entity)
    {
        return Table.ContainsKey(entity);
    }

    public virtual void Remove(Entity entity)
    {
        if(Table.ContainsKey(entity))
            Table.Remove(entity);
    }
}