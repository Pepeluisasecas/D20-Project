public partial class Data
{
    public CoreDictionary<Entity, string> name = new CoreDictionary<Entity, string>();
}

public interface INameSystem : IDependency<INameSystem>, IEntityTableSystem<string>
{

}

public class NameSystem : EntityTableSystem<string>, INameSystem
{
    public override CoreDictionary<Entity, string> Table => IDataSystem.Resolve().Data.name;
}

public partial struct Entity
{
    public string Name
    {
        get { return INameSystem.Resolve().Get(this); }
        set { INameSystem.Resolve().Set(this, value);}
    }
}