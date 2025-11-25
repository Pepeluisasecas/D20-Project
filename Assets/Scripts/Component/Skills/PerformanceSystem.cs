public partial class Data
{
    public CoreDictionary<Entity, int> performance = new CoreDictionary<Entity, int>();
}

public interface IPerformanceSystem : IDependency<IPerformanceSystem>, IBaseSkillSystem
{
    
}

public class PerformanceSystem : BaseSkillSystem, IPerformanceSystem
{
    public override CoreDictionary<Entity, int> Table => IDataSystem.Resolve().Data.performance;
    protected override Skill Skill => Skill.Performance;
    protected override AbilityScore.Attribute Attribute => AbilityScore.Attribute.Strength;
}

public partial struct Entity
{
    public int Performance
    {
        get { return IPerformanceSystem.Resolve().Get(this);  }
        set { IPerformanceSystem.Resolve().Set(this,value);}
    }
}