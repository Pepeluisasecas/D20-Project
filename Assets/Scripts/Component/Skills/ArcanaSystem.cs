public partial class Data
{
    public CoreDictionary<Entity, int> arcana = new CoreDictionary<Entity, int>();
}

public interface IArcanaSystem : IDependency<IArcanaSystem>, IBaseSkillSystem
{
    
}

public class ArcanaSystem : BaseSkillSystem, IArcanaSystem
{
    public override CoreDictionary<Entity, int> Table => IDataSystem.Resolve().Data.arcana;
    protected override Skill Skill => Skill.Arcana;
    protected override AbilityScore.Attribute Attribute => AbilityScore.Attribute.Strength;
}

public partial struct Entity
{
    public int Arcana
    {
        get { return IArcanaSystem.Resolve().Get(this);  }
        set { IArcanaSystem.Resolve().Set(this,value);}
    }
}