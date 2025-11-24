using Cysharp.Threading.Tasks;
using UnityEngine;

public class Demo : MonoBehaviour
{
    [SerializeField] private Entry entry;

    async UniTaskVoid Start()
    {
        var panel = IEntryPanel.Resolve();
        panel.Setup(entry);
        await panel.TransitionIn();
    } 
}