public partial class Data
{
    public CoreDictionary<Entity, Proficiency> survivalProficiency = new CoreDictionary<Entity, Proficiency>();
}

public interface ISurvivalProficiencySystem : IDependency<ISurvivalProficiencySystem>, IEntityTableSystem<Proficiency>
{
    
}

public class SurvivalProficiencySystem : EntityTableSystem<Proficiency>, ISurvivalProficiencySystem
{
    public override CoreDictionary<Entity, Proficiency> Table => IDataSystem.Resolve().Data.survivalProficiency;
}