using UnityEngine;
using UnityEngine.SceneManagement;
using Cysharp.Threading.Tasks;

public interface IMainMenuFlow : IDependency<IMainMenuFlow>
{
    UniTask<MainMenuOption> Play();
}

public class MainMenuFlow : IMainMenuFlow
{
    public async UniTask<MainMenuOption> Play()
    {
        // MARK: - Enter
        await SceneManager.LoadSceneAsync("MainMenu");
        var canContinue = IDataSystem.Resolve().HasFile();
        var menu = IMainMenu.Resolve();
        menu.Setup(canContinue);
        await menu.TransitionIn();
        
        // MARK: - Main Loop
        var result = await menu.SelectMenuOption();
        
        // MARK: - Exit
        await menu.TransitionOut();
        return result;
    }
}