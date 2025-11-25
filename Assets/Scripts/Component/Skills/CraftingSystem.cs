public partial class Data
{
    public CoreDictionary<Entity, int> crafting = new CoreDictionary<Entity, int>();
}

public interface ICraftingSystem : IDependency<ICraftingSystem>, IBaseSkillSystem
{
    
}

public class CraftingSystem : BaseSkillSystem, ICraftingSystem
{
    public override CoreDictionary<Entity, int> Table => IDataSystem.Resolve().Data.crafting;
    protected override Skill Skill => Skill.Crafting;
    protected override AbilityScore.Attribute Attribute => AbilityScore.Attribute.Strength;
}

public partial struct Entity
{
    public int Crafting
    {
        get { return ICraftingSystem.Resolve().Get(this);  }
        set { ICraftingSystem.Resolve().Set(this,value);}
    }
}