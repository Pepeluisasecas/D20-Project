using NUnit.Framework;

public class DataSystemTests
{
    MockDataSerializer mockDataSerializer = new MockDataSerializer();
    MockDataStore mockDataStore = new MockDataStore();
    DataSystem sut = new DataSystem();

    [SetUp]
    public void SetUp()
    {
        IDataSerializer.Register(mockDataSerializer);
        IDataStore.Register(mockDataStore);
    }

    [TearDown]
    public void TearDown()
    {
        IDataSerializer.Reset();
        IDataStore.Reset();
    }

    [Test]
    public void Create_InitsData()
    {
        var dataBefore = sut.Data;
        sut.Create();
        Assert.IsNull(dataBefore);
        Assert.IsNotNull(sut.Data);
    }

    [Test]
    public void Delete_WrapsStore()
    {
        sut.Delete();
        Assert.IsTrue(mockDataStore.DidCallDelete);
    }

    [Test]
    public void HasFile_WrapsStore()
    {
        mockDataStore.fakeHasFile = true;
        var result = sut.HasFile();
        Assert.IsTrue(mockDataStore.DidCallHasFile);
        Assert.AreEqual(mockDataStore.fakeHasFile, result);
    }

    [Test]
    public void Save_Success()
    {
        mockDataSerializer.fakeSerializeResult = "abc123";
        sut.Create();
        sut.Data.version = 1;
        sut.Save();
        Assert.IsTrue(mockDataSerializer.DidCallSerialize);
        Assert.AreEqual(sut.Data, mockDataSerializer.SerializeDataParam);
        Assert.IsTrue(mockDataStore.DidCallWrite);
        Assert.AreEqual(mockDataSerializer.fakeSerializeResult, mockDataStore.WriteJsonParam);
    }

    [Test]
    public void Load_Success()
    {
        mockDataSerializer.fakeDeserializeResult = new Data();
        mockDataStore.fakeReadResult = "abc123";
        sut.Load();
        Assert.IsTrue(mockDataStore.DidCallRead);
        Assert.IsTrue(mockDataSerializer.DidCallDeserialize);
        Assert.AreEqual(mockDataStore.fakeReadResult, mockDataSerializer.DeserializeJsonParam);
        Assert.AreEqual(mockDataSerializer.fakeDeserializeResult, sut.Data);
    }
}