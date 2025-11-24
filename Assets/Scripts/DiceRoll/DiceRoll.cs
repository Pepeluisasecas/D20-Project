using System;

[Serializable]
public partial struct DiceRoll
{
    public int count;
    public int sides;
    public int bonus;

    public DiceRoll(int sides)
    {
        this.count = 1;
        this.sides = sides;
        this.bonus = 0;
    }

    public DiceRoll(int count, int sides)
    {
        this.count = count;
        this.sides = sides;
        this.bonus = 0;
    }

    public DiceRoll(int count, int sides, int bonus)
    {
        this.count = count;
        this.sides = sides;
        this.bonus = bonus;
    }
    
    public static readonly DiceRoll D6 = new DiceRoll(6);
    public static readonly DiceRoll D20 = new DiceRoll(20);
}
