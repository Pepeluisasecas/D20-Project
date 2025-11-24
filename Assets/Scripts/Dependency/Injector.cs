public static class Injector
{
    public static void Inject()
    {
        AssetManagerInjector.Inject();
        ComponentInjector.Inject();
        DataInjector.Inject();
        DiceRollInjector.Inject();
        FlowInjector.Inject();
        IEntitySystem.Register(new EntitySystem());
        IGameSystem.Register(new GameSystem());
        SoloAdventureInjector.Inject();
    }
}
