public enum AdventureItem
{
    SkeletonKey,
    Torch
}

public partial class Data
{
    public CoreSet<AdventureItem> items = new CoreSet<AdventureItem>();
}

public interface IAdventureItemSystem : IDependency<IAdventureItemSystem>
{
    void Take(AdventureItem item);
    void Drop(AdventureItem item);
    bool Has(AdventureItem item);
}

public class AdventureItemSystem : IAdventureItemSystem
{
    CoreSet<AdventureItem> Items {get{return IDataSystem.Resolve().Data.items;}}

    public void Take(AdventureItem item)
    {
        Items.Add(item);
    }

    public void Drop(AdventureItem item)
    {
        Items.Remove(item);
    }

    public bool Has(AdventureItem item)
    {
        return Items.Contains(item);
    }
}