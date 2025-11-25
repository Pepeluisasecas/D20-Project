using System.Collections.Generic;
using NUnit.Framework;

public class MockAbilityScoreSystem : IAbilityScoreSystem
{
    Dictionary<Entity, Dictionary<AbilityScore.Attribute, AbilityScore>> fakeTable = new Dictionary<Entity, Dictionary<AbilityScore.Attribute, AbilityScore>>();

    public AbilityScore Get(Entity entity, AbilityScore.Attribute attribute)
    {
        if (fakeTable.ContainsKey(entity))
        {
            var map = fakeTable[entity];
            if (map.ContainsKey(attribute))
                return map[attribute];
        }
        return new AbilityScore(0);
    }

    public void Set(Entity entity, AbilityScore.Attribute attribute, AbilityScore value)
    {
        if (!fakeTable.ContainsKey(entity))
            fakeTable[entity] = new Dictionary<AbilityScore.Attribute, AbilityScore>();
        fakeTable[entity][attribute] = value;
    }

    public void Set(Entity entity, IEnumerable<int> scores)
    {
        Assert.Fail("Using un-implemented mock feature");
    }
}