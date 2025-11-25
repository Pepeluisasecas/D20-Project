using NUnit.Framework;

public class BaseSkillSystemTests
{
    [SetUp]
    public void Setup()
    {
        IAbilityScoreSystem.Register(new MockAbilityScoreSystem());
        IDataSystem.Register(new MockDataSystem());
        ILevelSystem.Register(new LevelSystem());
        IProficiencySystem.Register(new MockProficiencySystem());
        
        IDataSystem.Resolve().Create();
    }

    [TearDown]
    public void TearDown()
    {
        IAbilityScoreSystem.Reset();
        IDataSystem.Reset();
        ILevelSystem.Reset();
        IProficiencySystem.Reset();
    }

    [Test]
    public void Setup_TrainedEntity_AssignsCorrectSkillValue()
    {
        // Arrange
        var sut = new MockBaseSkillSystem(Skill.Athletics, AbilityScore.Attribute.Strength);
        var hero = new Entity(1);
        hero[AbilityScore.Attribute.Strength] = 18;
        hero.Level = 1;
        IProficiencySystem.Resolve().Set(hero,Skill.Athletics,Proficiency.Trained);
        
        // Act
        sut.Setup(hero);
        
        // Assert
        Assert.AreEqual(7,sut.Table[hero]); // 4 (Str) + 3 (Prof)
    }

    [Test]
    public void Setup_UntrainedEntity_AssignsCorrectSkillValue()
    {
        // Arrange
        var sut = new MockBaseSkillSystem(Skill.Athletics, AbilityScore.Attribute.Strength);
        var hero = new Entity(1);
        hero[AbilityScore.Attribute.Strength] = 12;
        hero.Level = 1;
        IProficiencySystem.Resolve().Set(hero,Skill.Athletics,Proficiency.Untrained);
        
        // Act
        sut.Setup(hero);
        
        // Assert
        Assert.AreEqual(1, sut.Table[hero]); // 1 (Str) + 0 (Prof)
    }
}
