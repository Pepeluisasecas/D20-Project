using System.Collections.Generic;
using UnityEngine;

public class MockSequenceRNG : IRandomNumberGenerator
{
    public Queue<int> values;
    public int fallback;

    public MockSequenceRNG(params int[] values)
    {
        this.values = new Queue<int>(values);
        this.fallback = 0;
    }

    public int Range(int minInclusive, int maxExclusive)
    {
        if (values.Count > 0)
            return values.Dequeue();
        return fallback;
    }
}
