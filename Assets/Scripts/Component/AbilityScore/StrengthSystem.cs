public partial class Data
{
    public CoreDictionary<Entity, AbilityScore> strength = new CoreDictionary<Entity, AbilityScore>();
}

public interface IStrengthSystem : IDependency<IStrengthSystem>, IEntityTableSystem<AbilityScore>
{
    
}

public class StrengthSystem : EntityTableSystem<AbilityScore>, IStrengthSystem
{
    public override CoreDictionary<Entity, AbilityScore> Table => IDataSystem.Resolve().Data.strength;
}

public partial struct Entity
{
    public AbilityScore Strength
    {
        get { return IStrengthSystem.Resolve().Get(this); }
        set { IStrengthSystem.Resolve().Set(this,value); }
    }
}