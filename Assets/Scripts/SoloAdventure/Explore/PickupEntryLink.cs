using UnityEngine;
using Cysharp.Threading.Tasks;

public class PickupEntryLink : MonoBehaviour, IEntryLink
{
    [SerializeField] private AdventureItem item;
    [SerializeField] private string takeMessage;
    [SerializeField] private string dropMessage;

    public async UniTask Select(string link)
    {
        if (link != "pickup")
            return;

        var system = IAdventureItemSystem.Resolve();
        if (!system.Has(item))
        {
            system.Take(item);
            await IAlert.Resolve().Show(takeMessage);
        }
        else
        {
            system.Drop(item);
            await IAlert.Resolve().Show(dropMessage);
        }
    }
}
