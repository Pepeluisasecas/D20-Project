using UnityEngine;
using UnityEngine.Serialization;

public class Checkpoint : MonoBehaviour
{
    [FormerlySerializedAs("diceRoll")] [SerializeField] AlternateDiceRoll alternateDiceRoll = new(6);
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            int result = alternateDiceRoll.Roll();
            
            Debug.Log("Final result: "+result);
        }
    }
}
