public partial class Data
{
    public CoreDictionary<Entity, Proficiency> athleticsProficiency = new CoreDictionary<Entity, Proficiency>();
}

public interface IAthleticsProficiencySystem : IDependency<IAthleticsProficiencySystem>, IEntityTableSystem<Proficiency>
{
    
}

public class AthleticsProficiencySystem : EntityTableSystem<Proficiency>, IAthleticsProficiencySystem
{
    public override CoreDictionary<Entity, Proficiency> Table => IDataSystem.Resolve().Data.athleticsProficiency;
}