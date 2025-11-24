public static class DiceRollInjector
{
    public static void Inject()
    {
        IDiceRollSystem.Register(new DiceRollSystem());
        IRandomNumberGenerator.Register(new RandomNumberGenerator());
    } 
}
