public partial class Data
{
    public CoreDictionary<Entity, AbilityScore> wisdom = new CoreDictionary<Entity, AbilityScore>();
}

public interface IWisdomSystem : IDependency<IWisdomSystem>, IEntityTableSystem<AbilityScore>
{
    
}

public class WisdomSystem : EntityTableSystem<AbilityScore>, IWisdomSystem
{
    public override CoreDictionary<Entity, AbilityScore> Table => IDataSystem.Resolve().Data.wisdom;
}

public partial struct Entity
{
    public AbilityScore Wisdom
    {
        get { return IWisdomSystem.Resolve().Get(this); }
        set { IWisdomSystem.Resolve().Set(this,value); }
    }
}