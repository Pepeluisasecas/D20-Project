public class MockBaseSkillSystem : BaseSkillSystem
{
    CoreDictionary<Entity, int> fakeTable = new CoreDictionary<Entity, int>();
    Skill fakeSkill;
    AbilityScore.Attribute fakeAttribute;

    public MockBaseSkillSystem(Skill fakeSkill, AbilityScore.Attribute fakeAttribute)
    {
        this.fakeSkill = fakeSkill;
        this.fakeAttribute = fakeAttribute;
    }
    
    public override CoreDictionary<Entity,int> Table => fakeTable;
    protected override Skill Skill => fakeSkill;
    protected override AbilityScore.Attribute Attribute => fakeAttribute;
}