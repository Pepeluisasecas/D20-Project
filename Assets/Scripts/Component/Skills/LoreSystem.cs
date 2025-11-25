public partial class Data
{
    public CoreDictionary<Entity, int> lore = new CoreDictionary<Entity, int>();
}

public interface ILoreSystem : IDependency<ILoreSystem>, IBaseSkillSystem
{
    
}

public class LoreSystem : BaseSkillSystem, ILoreSystem
{
    public override CoreDictionary<Entity, int> Table => IDataSystem.Resolve().Data.lore;
    protected override Skill Skill => Skill.Lore;
    protected override AbilityScore.Attribute Attribute => AbilityScore.Attribute.Strength;
}

public partial struct Entity
{
    public int Lore
    {
        get { return ILoreSystem.Resolve().Get(this);  }
        set { ILoreSystem.Resolve().Set(this,value);}
    }
}