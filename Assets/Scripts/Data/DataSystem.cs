using UnityEngine;
using UnityEngine.UI;

public interface IDataSystem : IDependency<IDataSystem>
{
    Data Data { get; }

    void Create();
    void Delete();
    bool HasFile();
    void Save();
    void Load();

}

public class DataSystem : IDataSystem
{
    public Data Data { get; private set; }

    public void Create()
    {
        Data = new Data();
    }

    public void Delete()
    {
        IDataStore.Resolve().Delete();
    }

    public bool HasFile()
    {
        return IDataStore.Resolve().HasFile();
    }

    public void Save()
    {
        var json = IDataSerializer.Resolve().Serialize(Data);
        IDataStore.Resolve().Write(json);
    }

    public void Load()
    {
        var json = IDataStore.Resolve().Read();
        Data = IDataSerializer.Resolve().Deserialize(json);
    }
}
