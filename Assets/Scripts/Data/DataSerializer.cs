using UnityEngine;

public interface IDataSerializer : IDependency<IDataSerializer>
{
    string Serialize(Data data);
    Data Deserialize(string json);
}

public class DataSerializer : IDataSerializer
{
    public string Serialize(Data data)
    {
        return JsonUtility.ToJson(data);
    }

    public Data Deserialize(string json)
    {
        return JsonUtility.FromJson<Data>(json);
    }
}

