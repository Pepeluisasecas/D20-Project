public partial class Data
{
    public CoreDictionary<Entity, AbilityScore> intelligence = new CoreDictionary<Entity, AbilityScore>();
}

public interface IIntelligenceSystem : IDependency<IIntelligenceSystem>, IEntityTableSystem<AbilityScore>
{
    
}

public class IntelligenceSystem : EntityTableSystem<AbilityScore>, IIntelligenceSystem
{
    public override CoreDictionary<Entity, AbilityScore> Table => IDataSystem.Resolve().Data.intelligence;
}

public partial struct Entity
{
    public AbilityScore Intelligence
    {
        get { return IIntelligenceSystem.Resolve().Get(this); }
        set { IIntelligenceSystem.Resolve().Set(this,value); }
    }
}