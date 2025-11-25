public partial class Data
{
    public CoreDictionary<Entity, int> intimidation = new CoreDictionary<Entity, int>();
}

public interface IIntimidationSystem : IDependency<IIntimidationSystem>, IBaseSkillSystem
{
    
}

public class IntimidationSystem : BaseSkillSystem, IIntimidationSystem
{
    public override CoreDictionary<Entity, int> Table => IDataSystem.Resolve().Data.intimidation;
    protected override Skill Skill => Skill.Intimidation;
    protected override AbilityScore.Attribute Attribute => AbilityScore.Attribute.Strength;
}

public partial struct Entity
{
    public int Intimidation
    {
        get { return IIntimidationSystem.Resolve().Get(this);  }
        set { IIntimidationSystem.Resolve().Set(this,value);}
    }
}