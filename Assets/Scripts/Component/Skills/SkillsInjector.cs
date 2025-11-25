public static class SkillsInjector
{
    public static void Inject()
    {
        IAcrobaticsProficiencySystem.Register(new AcrobaticsProficiencySystem());
        IAcrobaticsSystem.Register(new AcrobaticsSystem());
        IArcanaProficiencySystem.Register(new ArcanaProficiencySystem());
        IArcanaSystem.Register(new ArcanaSystem());
        IAthleticsProficiencySystem.Register(new AthleticsProficiencySystem());
        IAthleticsSystem.Register(new AthleticsSystem());
        ICraftingProficiencySystem.Register(new CraftingProficiencySystem());
        ICraftingSystem.Register(new CraftingSystem());
        IDeceptionProficiencySystem.Register(new DeceptionProficiencySystem());
        IDeceptionSystem.Register(new DeceptionSystem());
        IDiplomacyProficiencySystem.Register(new DiplomacyProficiencySystem());
        IDiplomacySystem.Register(new DiplomacySystem());
        IIntimidationProficiencySystem.Register(new IntimidationProficiencySystem());
        IIntimidationSystem.Register(new IntimidationSystem());
        ILoreProficiencySystem.Register(new LoreProficiencySystem());
        ILoreSystem.Register(new LoreSystem());
        IMedicineProficiencySystem.Register(new MedicineProficiencySystem());
        IMedicineSystem.Register(new MedicineSystem());
        INatureProficiencySystem.Register(new NatureProficiencySystem());
        INatureSystem.Register(new NatureSystem());
        IOccultismProficiencySystem.Register(new OccultismProficiencySystem());
        IOccultismSystem.Register(new OccultismSystem());
        IPerformanceProficiencySystem.Register(new PerformanceProficiencySystem());
        IPerformanceSystem.Register(new PerformanceSystem());
        IReligionProficiencySystem.Register(new ReligionProficiencySystem());
        IReligionSystem.Register(new ReligionSystem());
        ISocietyProficiencySystem.Register(new SocietyProficiencySystem());
        ISocietySystem.Register(new SocietySystem());
        IStealthProficiencySystem.Register(new StealthProficiencySystem());
        IStealthSystem.Register(new StealthSystem());
        ISurvivalProficiencySystem.Register(new SurvivalProficiencySystem());
        ISurvivalSystem.Register(new SurvivalSystem());
        IThieveryProficiencySystem.Register(new ThieveryProficiencySystem());
        IThieverySystem.Register(new ThieverySystem());
        IProficiencySystem.Register(new ProficiencySystem());
        ISkillSystem.Register(new SkillSystem());
    }
}