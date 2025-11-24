using UnityEngine;
using Cysharp.Threading.Tasks;

public interface IEntryAssetSystem : IDependency<IEntryAssetSystem>
{
    UniTask<IEntry> Load();
    UniTask<IEntry> Load(string entryName);
}

public class EntryAssetSystem : IEntryAssetSystem
{
    public async UniTask<IEntry> Load()
    {
        var entryName = IEntrySystem.Resolve().GetName();
        return await Load(entryName);
    }

    public async UniTask<IEntry> Load(string entryName)
    {
        var assetManager = IAssetManager<GameObject>.Resolve();
        var key = string.Format("Assets/Objects/Entries/{0}.prefab", entryName);
        var asset = await assetManager.LoadAssetAsync(key);
        return asset.GetComponent<IEntry>();
    }
}
