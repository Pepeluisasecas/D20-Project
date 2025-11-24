using NUnit.Framework;
using UnityEngine;

public class CoreDictionaryTests
{
    const int key = 1;
    const int value = 3;

    [Test]
    public void Add_And_Remove_Success()
    {
        CoreDictionary<int, int> sut = new CoreDictionary<int, int>();
        sut.Add(key, value);
        Assert.AreEqual(1, sut.Count);
        Assert.AreEqual(value, sut[key]);

        sut.Remove(key);
        Assert.IsEmpty(sut);
    }
    
    const string json = "{\"keys\":[1],\"values\":[3]}";

    [Test]
    public void JsonUtility_Serialization_Success()
    {
        CoreDictionary<int, int> sut = new CoreDictionary<int, int>();
        sut.Add(key, value);
        var result = JsonUtility.ToJson(sut);
        Assert.AreEqual(json, result);
    }
    
    [Test]
    public void JsonUtility_Deserialization_Success()
    {
        CoreDictionary<int, int> sut = new CoreDictionary<int, int>();
        JsonUtility.FromJsonOverwrite(json, sut);
        Assert.AreEqual(1, sut.Count);
        Assert.AreEqual(value, sut[key]);
    }
}