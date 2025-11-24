using System.Collections.Generic;
using UnityEngine;

public class AlternateDiceRollSystem
{
    public int Roll(AlternateDiceRoll alternateDiceRoll)
    {
        int finalResult = alternateDiceRoll.finalModifier;
        List<int> setResults = new List<int>();
        
        for (int i = 0; i < alternateDiceRoll.sets; i++)
        {
            int result = alternateDiceRoll.modifier;
            
            for (int j = 0; j < alternateDiceRoll.count; j++)
            {
                result+= Random.Range(1,alternateDiceRoll.sides+1);
            }
            
            Debug.Log("Set result: "+result);
            
            setResults.Add(result);
            
        }
        
        if(alternateDiceRoll.keptSetsType == KeptSetsType.Lowest) setResults.Sort();
        if(alternateDiceRoll.keptSetsType == KeptSetsType.Highest) setResults.Sort((a, b) => b.CompareTo(a));

        for (int i = 0; i < alternateDiceRoll.keptSets; i++)
        {
            
            finalResult += setResults[i];
        }
        
        return finalResult;
    }
}
