public partial class Data
{
    public CoreSet<Entity> entities = new CoreSet<Entity>();
}

public interface IEntitySystem : IDependency<IEntitySystem>
{
    Entity Create();
    void Destroy(Entity entity);
}

public class EntitySystem : IEntitySystem
{
    Data Data { get { return IDataSystem.Resolve().Data; }}
    IRandomNumberGenerator RNG { get { return IRandomNumberGenerator.Resolve(); }}

    public Entity Create()
    {
        Entity result;
        do
        {
            result = new Entity(RNG.Range(int.MinValue,int.MaxValue));
        }
        while(result.id == 0 || Data.entities.Contains(result));
        Data.entities.Add(result);
        return result;
    }

    public void Destroy(Entity entity)
    {
        Data.entities.Remove(entity);
        
    }
}