public partial class Data
{
    public CoreDictionary<Entity,int> level = new CoreDictionary<Entity,int>();
}

public interface ILevelSystem : IDependency<ILevelSystem>, IEntityTableSystem<int>
{
    
}

public class LevelSystem : EntityTableSystem<int>, ILevelSystem
{
    public override CoreDictionary<Entity,int> Table => IDataSystem.Resolve().Data.level;
}

public partial struct Entity
{
    public int Level
    {
        get { return ILevelSystem.Resolve().Get(this); }
        set { ILevelSystem.Resolve().Set(this,value); }
    }
}