using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Cysharp.Threading.Tasks;
using UnityEngine.UI;
using System.Threading;
using System.Linq;

public interface IEntryPanel : IDependency<IEntryPanel>
{
    void Setup(IEntry entry);
    UniTask TransitionIn();
    UniTask<int> SelectMenuOption(CancellationToken token);
    UniTask<string> SelectLink(CancellationToken token);
    UniTask TransitionOut();
}

public class EntryPanel : MonoBehaviour, IEntryPanel
{
    [SerializeField] CanvasGroup canvasGroup;
    [SerializeField] TextMeshProUGUI entryText;
    [SerializeField] List<GameObject> entryOptions;

    public void Setup(IEntry entry)
    {
        // Setup the main entry text
        entryText.text = entry.Text;
        
        // Setup buttons for entry options
        var pairs = entryOptions.Zip(entry.Options, (GameObject view, IEntryOption data) => (view, data));
        foreach (var pair in pairs)
        {
            pair.view.SetActive(true);
            var label = pair.view.GetComponentInChildren<TextMeshProUGUI>();
            label.text = pair.data.Text;
        }
        
        // Hide any unused buttons
        for (int i = pairs.Count(); i < entryOptions.Count(); i++)
            entryOptions[i].SetActive(false);
    }

    private const float transitionTime = .25f;

    public async UniTask TransitionIn()
    {
        await canvasGroup.FadeIn(transitionTime, EasingEquations.EaseInOutQuad).Play(this.GetCancellationTokenOnDestroy());
    }

    public async UniTask TransitionOut()
    {
        await canvasGroup.FadeOut(transitionTime, EasingEquations.EaseInOutQuad).Play(this.GetCancellationTokenOnDestroy());
    }

    public async UniTask<int> SelectMenuOption(CancellationToken token)
    {
        List<UniTask> tasks = new List<UniTask>(entryOptions.Count);
        
        for (int i = 0; i < entryOptions.Count; i++)
        {
            if(!entryOptions[i].activeSelf)
                break;
            var button = entryOptions[i].GetComponent<Button>();
            var task = Press(button, token);
            tasks.Add(task);
        }
        
        var result = await UniTask.WhenAny(tasks);
        return result;
    }

    async UniTask Press(Button button, CancellationToken token)
    {
        using (var handler = button.GetAsyncClickEventHandler(token))
        {
            await handler.OnClickAsync();
        }
    }

    public async UniTask<string> SelectLink(CancellationToken token)
    {
        var linkOpener = entryText.GetComponent<LinkOpener>();
        string result = "";
        using (var handler = linkOpener.onClick.GetAsyncEventHandler(token))
        {
            result = await handler.OnInvokeAsync();
        }
        return result;
    }

    private void Awake()
    {
        canvasGroup.alpha = 0;
    }

    private void OnEnable()
    {
        IEntryPanel.Register(this);
    }

    private void OnDisable()
    {
        IEntryPanel.Reset();
    }
}
