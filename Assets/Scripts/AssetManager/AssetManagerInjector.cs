public static class AssetManagerInjector
{
    public static void Inject()
    {
        IEntryAssetSystem.Register(new EntryAssetSystem());
    }
}