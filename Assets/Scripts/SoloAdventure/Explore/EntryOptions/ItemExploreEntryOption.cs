using UnityEngine;

public class ItemExploreEntryOption : MonoBehaviour, IEntryOption
{
    [SerializeField] private string text;
    [SerializeField] private AdventureItem item;
    [SerializeField] private string hasItemEntry;
    [SerializeField] private string noItemEntry;

    public string Text
    {
        get { return text; }
    }

    public void Select()
    {
        var entry = IAdventureItemSystem.Resolve().Has(item) ? hasItemEntry : noItemEntry;
        IEntrySystem.Resolve().SetName(entry);
    }
}
