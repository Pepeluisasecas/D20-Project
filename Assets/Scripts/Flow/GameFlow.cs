using System.Threading.Tasks;
using Cysharp.Threading.Tasks;

public interface IGameFlow : IDependency<IGameFlow>
{
    UniTask Play();
}

public class GameFlow : IGameFlow
{
    public async UniTask Play()
    {
        await Enter();
        await Loop();
        await Exit();
    }

    async UniTask Enter()
    {
        var option = await IMainMenuFlow.Resolve().Play();
        switch (option)
        {
            case MainMenuOption.Continue:
                await IGameSystem.Resolve().ContinueGame();
                break;
            case MainMenuOption.NewGame:
                await IGameSystem.Resolve().NewGame();
                break;
        }
    }

    async UniTask Loop()
    {
        while (true)
        {
            var entryName = IEntrySystem.Resolve().GetName();
            if (!string.IsNullOrEmpty(entryName))
                await IEntryFlow.Resolve().Play();
            else
                break;
            await UniTask.NextFrame();
        }
    }

    async UniTask Exit()
    {
        IDataSystem.Resolve().Delete();
        await UniTask.CompletedTask;
    }
}