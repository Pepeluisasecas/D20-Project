public enum Proficiency
{
    Untrained,
    Trained,
    Expert,
    Mater,
    Legendary
}

public interface IProficiencySystem : IDependency<IProficiencySystem>
{
    Proficiency Get (Entity entity, Skill skill);
    void Set(Entity entity, Skill skill, Proficiency value);
}

public class ProficiencySystem : IProficiencySystem
{
    public Proficiency Get(Entity entity, Skill skill)
    {
        return GetSystem(skill).Get(entity);
    }

    public void Set(Entity entity, Skill skill, Proficiency value)
    {
        GetSystem(skill).Set(entity, value);
    }

    IEntityTableSystem<Proficiency> GetSystem(Skill skill)
    {
        switch (skill)
        {
            case Skill.Athletics:
                return IAthleticsProficiencySystem.Resolve();
            default:
                return null;
        }
    }
}