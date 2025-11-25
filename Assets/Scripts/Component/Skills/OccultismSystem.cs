public partial class Data
{
    public CoreDictionary<Entity, int> occultism = new CoreDictionary<Entity, int>();
}

public interface IOccultismSystem : IDependency<IOccultismSystem>, IBaseSkillSystem
{
    
}

public class OccultismSystem : BaseSkillSystem, IOccultismSystem
{
    public override CoreDictionary<Entity, int> Table => IDataSystem.Resolve().Data.occultism;
    protected override Skill Skill => Skill.Occultism;
    protected override AbilityScore.Attribute Attribute => AbilityScore.Attribute.Strength;
}

public partial struct Entity
{
    public int Occultism
    {
        get { return IOccultismSystem.Resolve().Get(this);  }
        set { IOccultismSystem.Resolve().Set(this,value);}
    }
}