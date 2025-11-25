public partial class Data
{
    public CoreDictionary<Entity, Proficiency> loreProficiency = new CoreDictionary<Entity, Proficiency>();
}

public interface ILoreProficiencySystem : IDependency<ILoreProficiencySystem>, IEntityTableSystem<Proficiency>
{
    
}

public class LoreProficiencySystem : EntityTableSystem<Proficiency>, ILoreProficiencySystem
{
    public override CoreDictionary<Entity, Proficiency> Table => IDataSystem.Resolve().Data.loreProficiency;
}