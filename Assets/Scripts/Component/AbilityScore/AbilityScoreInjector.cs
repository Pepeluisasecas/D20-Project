public static class AbilityScoreInjector
{
    public static void Inject()
    {
        IAbilityScoreSystem.Register(new AbilityScoreSystem());
        ICharismaSystem.Register(new CharismaSystem());
        IConstitutionSystem.Register(new ConstitutionSystem());
        IDexteritySystem.Register(new DexteritySystem());
        IIntelligenceSystem.Register(new IntelligenceSystem());
        IStrengthSystem.Register(new StrengthSystem());
        IWisdomSystem.Register(new WisdomSystem());
    }
}
