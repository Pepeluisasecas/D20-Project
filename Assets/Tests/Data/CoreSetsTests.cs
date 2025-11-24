using NUnit.Framework;
using UnityEngine;

public class CoreSetsTests
{
    [Test]
    public void Add_And_Remove_Success()
    {
        CoreSet<int> sut = new CoreSet<int>();
        sut.Add(42);
        Assert.AreEqual(1, sut.Count);
        Assert.True(sut.Contains(42));
        
        sut.Remove(42);
        Assert.IsEmpty(sut);
    }

    [Test]
    public void Add_Duplicate_IsIgnored()
    {
        CoreSet<int> sut = new CoreSet<int>();
        sut.Add(1);
        sut.Add(1);
        sut.Add(2);
        sut.Add(3);
        Assert.AreEqual(3, sut.Count);
    }

    private const string json = "{\"values\":[1]}";

    [Test]
    public void JsonUtility_Serialization_Success()
    {
        CoreSet<int> sut = new CoreSet<int>();
        sut.Add(1);
        var result = JsonUtility.ToJson(sut);
        Assert.AreEqual(json, result);
    }

    [Test]
    public void JsonUtility_Deserialization_Success()
    {
        CoreSet<int> sut = new CoreSet<int>();
        JsonUtility.FromJsonOverwrite(json, sut);
        Assert.AreEqual(1, sut.Count);
        Assert.True(sut.Contains(1));
    }
}
