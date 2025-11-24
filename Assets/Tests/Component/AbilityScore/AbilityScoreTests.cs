using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class AbilityScoreTests
{
    [Test]
    public void Modifier_Success()
    {
        Assert.AreEqual(-5,new AbilityScore(1).Modifier);
        Assert.AreEqual(-4,new AbilityScore(2).Modifier);
        Assert.AreEqual(-4,new AbilityScore(3).Modifier);
        Assert.AreEqual(0,new AbilityScore(10).Modifier);
        Assert.AreEqual(0,new AbilityScore(11).Modifier);
        Assert.AreEqual(1,new AbilityScore(12).Modifier);
        Assert.AreEqual(1,new AbilityScore(13).Modifier);
        Assert.AreEqual(5,new AbilityScore(20).Modifier);
        Assert.AreEqual(17,new AbilityScore(45).Modifier);
    }
}
