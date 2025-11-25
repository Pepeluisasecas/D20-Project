public partial class Data
{
    public CoreDictionary<Entity, Proficiency> diplomacyProficiency = new CoreDictionary<Entity, Proficiency>();
}

public interface IDiplomacyProficiencySystem : IDependency<IDiplomacyProficiencySystem>, IEntityTableSystem<Proficiency>
{
    
}

public class DiplomacyProficiencySystem : EntityTableSystem<Proficiency>, IDiplomacyProficiencySystem
{
    public override CoreDictionary<Entity, Proficiency> Table => IDataSystem.Resolve().Data.diplomacyProficiency;
}