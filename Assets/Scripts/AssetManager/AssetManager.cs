using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Cysharp.Threading.Tasks;
using UnityEngine.ResourceManagement.AsyncOperations;

public interface IAssetManager<T> : IDependency<IAssetManager<T>>
{
    UniTask<T> InstantiateAsync(string key);
    UniTask<T> LoadAssetAsync(string key);
}

public abstract class AssetManager<T> : MonoBehaviour, IAssetManager<T> where T : Object
{
    Dictionary<string, AsyncOperationHandle<T>> assetMap = new Dictionary<string, AsyncOperationHandle<T>>();

    public async UniTask<T> InstantiateAsync(string key)
    {
        var asset = await LoadAssetAsync(key);
        return Instantiate(asset);
    }

    public async UniTask<T> LoadAssetAsync(string key)
    {
        AsyncOperationHandle<T> handle;
        if (assetMap.ContainsKey(key))
        {
            handle = assetMap[key];
        }
        else
        {
            handle = Addressables.LoadAssetAsync<T>(key);
            assetMap.Add(key, handle);
        }

        if (!handle.IsDone)
            await handle;

        if (handle.Status == AsyncOperationStatus.Succeeded)
            return handle.Result;

        return null;
    }

    private void OnEnable()
    {
        IAssetManager<T>.Register(this);
    }

    private void OnDisable()
    {
        IAssetManager<T>.Reset();
    }

    private void OnDestroy()
    {
        foreach (var handle in assetMap.Values)
            Addressables.Release(handle);
    }
}