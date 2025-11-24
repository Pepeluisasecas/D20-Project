using NUnit.Framework;

public class EntitySystemTests
{
    MockDataSystem mockDataSystem = new MockDataSystem();
    EntitySystem sut = new EntitySystem();

    [SetUp]
    public void Setup()
    {
        IDataSystem.Register(mockDataSystem);
        mockDataSystem.Create();
    }

    [TearDown]
    public void TearDown()
    {
        IRandomNumberGenerator.Reset();
        IDataSystem.Reset();
    }

    [Test]
    public void Create_Succeeds()
    {
        IRandomNumberGenerator.Register(new MockFixedRNG(1));
        
        var entity = sut.Create();
        
        Assert.AreEqual(1,entity.id);
        Assert.True(mockDataSystem.Data.entities.Contains(entity));
    }
    
    [Test]
    public void Create_ZeroID_RollsAgain()
    {
        IRandomNumberGenerator.Register(new MockSequenceRNG(0, 1));

        var entity = sut.Create();
        
        Assert.AreEqual(1,entity.id);
    }

    [Test]
    public void Create_DuplicateID_RollsAgain()
    {
        IRandomNumberGenerator.Register(new MockSequenceRNG(1,2));
        mockDataSystem.Data.entities.Add(new Entity(1));
        
        var entity = sut.Create();
        
        Assert.AreEqual(2,entity.id);
    }

    [Test]
    public void Destroy_Succeeds()
    {
        var entity = new Entity(1);
        mockDataSystem.Data.entities.Add(entity);
        
        sut.Destroy(entity);
        
        Assert.IsFalse(mockDataSystem.Data.entities.Contains(entity));
    }
}