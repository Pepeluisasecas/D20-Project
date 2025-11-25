public partial class Data
{
    public CoreDictionary<Entity, int> deception = new CoreDictionary<Entity, int>();
}

public interface IDeceptionSystem : IDependency<IDeceptionSystem>, IBaseSkillSystem
{
    
}

public class DeceptionSystem : BaseSkillSystem, IDeceptionSystem
{
    public override CoreDictionary<Entity, int> Table => IDataSystem.Resolve().Data.deception;
    protected override Skill Skill => Skill.Deception;
    protected override AbilityScore.Attribute Attribute => AbilityScore.Attribute.Strength;
}

public partial struct Entity
{
    public int Deception
    {
        get { return IDeceptionSystem.Resolve().Get(this);  }
        set { IDeceptionSystem.Resolve().Set(this,value);}
    }
}