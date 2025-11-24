public static class FlowInjector
{
    public static void Inject()
    {
        IEntryFlow.Register(new EntryFlow());
        IGameFlow.Register(new GameFlow());
        IMainMenuFlow.Register(new MainMenuFlow());
    }
}
