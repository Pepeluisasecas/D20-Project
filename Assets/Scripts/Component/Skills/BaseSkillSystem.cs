public interface IBaseSkillSystem : IEntityTableSystem<int>
{
    void Setup(Entity entity);
}

public abstract class BaseSkillSystem : EntityTableSystem<int>, IBaseSkillSystem
{
    protected abstract Skill Skill { get; }
    protected abstract AbilityScore.Attribute Attribute { get; }

    public virtual void Setup(Entity entity)
    {
        Table[entity] = Calculate(entity);
    }

    protected virtual int Calculate(Entity entity)
    {
        int result = entity[Attribute].Modifier;
        var proficiency = IProficiencySystem.Resolve().Get(entity, Skill);
        if (proficiency != Proficiency.Untrained)
            result += (int)proficiency*2+entity.Level;
        return result;
    }
}