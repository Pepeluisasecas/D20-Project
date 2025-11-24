public static class DataInjector
{
    public static void Inject()
    {
        IDataSerializer.Register(new DataSerializer());
        IDataStore.Register(new DataStore("GameData"));
        IDataSystem.Register(new DataSystem());
    }
}
