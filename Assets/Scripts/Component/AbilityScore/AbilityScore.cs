[System.Serializable]

public struct AbilityScore
{
    public int value;

    public int Modifier => value / 2 - 5;

    public AbilityScore(int value)
    {
        this.value = value;
    }

    public enum Attribute
    {
        Strength,
        Dexterity,
        Constitution,
        Intelligence,
        Wisdom,
        Charisma
    }
    
    public static implicit operator int(AbilityScore score) => score.value;
    public static implicit operator AbilityScore(int score) => new AbilityScore(score);
}
