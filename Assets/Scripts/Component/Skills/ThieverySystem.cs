public partial class Data
{
    public CoreDictionary<Entity, int> thievery = new CoreDictionary<Entity, int>();
}

public interface IThieverySystem : IDependency<IThieverySystem>, IBaseSkillSystem
{
    
}

public class ThieverySystem : BaseSkillSystem, IThieverySystem
{
    public override CoreDictionary<Entity, int> Table => IDataSystem.Resolve().Data.thievery;
    protected override Skill Skill => Skill.Thievery;
    protected override AbilityScore.Attribute Attribute => AbilityScore.Attribute.Strength;
}

public partial struct Entity
{
    public int Thievery
    {
        get { return IThieverySystem.Resolve().Get(this);  }
        set { IThieverySystem.Resolve().Set(this,value);}
    }
}