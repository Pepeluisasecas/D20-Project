public static class ComponentInjector
{
    public static void Inject()
    {
        AbilityScoreInjector.Inject();
        IAdventureItemSystem.Register(new AdventureItemSystem());
        ILevelSystem.Register(new LevelSystem());
        INameSystem.Register(new NameSystem());
        SkillsInjector.Inject();
    }
}
