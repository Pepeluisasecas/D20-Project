public enum Skill
{
    Acrobatics,
    Arcana,
    Athletics,
    Crafting,
    Deception,
    Diplomacy,
    Intimidation,
    Lore,
    Medicine,
    Nature,
    Occultism,
    Performance,
    Religion,
    Society,
    Stealth,
    Survival,
    Thievery
}

public interface ISkillSystem : IDependency<ISkillSystem>
{
    void Set(Entity entity, Skill skill, int value);
    int Get(Entity entity, Skill skill);
}

public class SkillSystem : ISkillSystem
{
    public void Set(Entity entity, Skill skill, int value)
    {
        GetSystem(skill).Set(entity,value);
    }

    public int Get(Entity entity, Skill skill)
    {
        return GetSystem(skill).Get(entity);
    }
    
    IEntityTableSystem<int> GetSystem(Skill skill)
    {
        switch (skill)
        {
            case Skill.Athletics:
                return IAthleticsSystem.Resolve();
            default:
                return null;
        }
    }
}

public partial struct Entity
{
    public int this[Skill skill]
    {
        get { return ISkillSystem.Resolve().Get(this, skill); }
        set { ISkillSystem.Resolve().Set(this, skill, value); }
    }
}