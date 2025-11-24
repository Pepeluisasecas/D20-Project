using System;
using NUnit.Framework;
using UnityEngine;

/* FORMAT
 N(NdS+#)-#L
 d: Dice designation identifier 
 N: Times the next item repeats
 S: Dice side number
 +: Add the next item
 -: Subtract the next item
 -#[L/H]: Remove the #th [L]owest or [H]ighest rolls of the previous item
 +#[L/H]: Keep only the #th [L]owest or [H]ighest rolls of the previous item
 
*/


[Serializable]
public class AlternateDiceRoll
{
    public int count=1;
    public int sides;
    public int modifier;
    public int sets=1;
    public int keptSets=1;
    public KeptSetsType keptSetsType;
    public int finalModifier;
    
    private AlternateDiceRollSystem _alternateDiceRollSystem = new AlternateDiceRollSystem();
    
    public AlternateDiceRoll(int sides,int count=1, int modifier = 0, int sets = 1, int keptSets = 1, KeptSetsType keptSetsType = KeptSetsType.Highest, int finalModifier = 0)
    {
       this.sides = sides;
       this.count = count;
       this.modifier = modifier;
       this.sets = sets;
       this.keptSets = keptSets;
       this.keptSetsType = keptSetsType;
       this.finalModifier = finalModifier;
    }

    public int Roll()
    {
        return _alternateDiceRollSystem.Roll(this);
    }
}

public enum KeptSetsType
{
    Highest,
    H = Highest,
    Lowest,
    L = Lowest
}
