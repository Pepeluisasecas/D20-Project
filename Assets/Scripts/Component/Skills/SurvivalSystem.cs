public partial class Data
{
    public CoreDictionary<Entity, int> survival = new CoreDictionary<Entity, int>();
}

public interface ISurvivalSystem : IDependency<ISurvivalSystem>, IBaseSkillSystem
{
    
}

public class SurvivalSystem : BaseSkillSystem, ISurvivalSystem
{
    public override CoreDictionary<Entity, int> Table => IDataSystem.Resolve().Data.survival;
    protected override Skill Skill => Skill.Survival;
    protected override AbilityScore.Attribute Attribute => AbilityScore.Attribute.Strength;
}

public partial struct Entity
{
    public int Survival
    {
        get { return ISurvivalSystem.Resolve().Get(this);  }
        set { ISurvivalSystem.Resolve().Set(this,value);}
    }
}