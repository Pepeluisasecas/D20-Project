using UnityEngine;

public class ExploreEntryOption : MonoBehaviour, IEntryOption
{
    [SerializeField] string text;
    [SerializeField] private string entryName;
    
    public string Text { get{return text;} }

    public void Select()
    {
        IEntrySystem.Resolve().SetName(entryName);
    }
}