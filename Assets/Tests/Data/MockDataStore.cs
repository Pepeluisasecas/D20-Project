using UnityEngine;

public class MockDataStore : IDataStore
{
    public bool fakeHasFile;
    public string fakeReadResult;

    public bool DidCallDelete { get; private set; }
    public bool DidCallHasFile { get; private set; }
    public bool DidCallRead { get; private set; }
    public bool DidCallWrite { get; private set; }
    public string WriteJsonParam { get; private set; }

    public void Delete()
    {
        DidCallDelete = true;
    }

    public bool HasFile()
    {
        DidCallHasFile = true;
        return fakeHasFile;
    }

    public string Read()
    {
        DidCallRead = true;
        return fakeReadResult;
    }

    public void Write(string json)
    {
        DidCallWrite = true;
        WriteJsonParam = json;
    }
}
