using UnityEngine;

public interface IRandomNumberGenerator : IDependency<IRandomNumberGenerator>
{
    public int Range(int minInclusive, int maxExclusive);
}

public struct RandomNumberGenerator : IRandomNumberGenerator
{
    public int Range(int minInclusive, int maxExclusive)
    {
        return Random.Range(minInclusive, maxExclusive);
    }
}

