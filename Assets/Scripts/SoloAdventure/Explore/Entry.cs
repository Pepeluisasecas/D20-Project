using UnityEngine;
using Cysharp.Threading.Tasks;

public interface IEntry
{
    string Text { get; }
    IEntryOption[] Options { get; }
    UniTask SelectLink(string link);
}

public class Entry : MonoBehaviour, IEntry
{
    [SerializeField] string text;

    public string Text { get { return text; } }
    public IEntryOption[] Options { get { return GetComponents<IEntryOption>(); } }

    public async UniTask SelectLink(string link)
    {
        await GetComponent<IEntryLink>().Select(link);
    }
}
