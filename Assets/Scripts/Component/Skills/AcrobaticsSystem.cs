public partial class Data
{
    public CoreDictionary<Entity, int> acrobatics = new CoreDictionary<Entity, int>();
}

public interface IAcrobaticsSystem : IDependency<IAcrobaticsSystem>, IBaseSkillSystem
{
    
}

public class AcrobaticsSystem : BaseSkillSystem, IAcrobaticsSystem
{
    public override CoreDictionary<Entity, int> Table => IDataSystem.Resolve().Data.acrobatics;
    protected override Skill Skill => Skill.Acrobatics;
    protected override AbilityScore.Attribute Attribute => AbilityScore.Attribute.Strength;
}

public partial struct Entity
{
    public int Acrobatics
    {
        get { return IAcrobaticsSystem.Resolve().Get(this);  }
        set { IAcrobaticsSystem.Resolve().Set(this,value);}
    }
}