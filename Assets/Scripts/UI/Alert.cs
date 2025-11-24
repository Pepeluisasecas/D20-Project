using System;
using UnityEngine;
using Cysharp.Threading.Tasks;
using UnityEngine.UI;
using TMPro;

public interface IAlert : IDependency<IAlert>
{
    UniTask Show(string message);
}

public class Alert : MonoBehaviour, IAlert
{
    [SerializeField] RectTransform rootPanel;
    [SerializeField] TextMeshProUGUI label;
    [SerializeField] Button button;

    public async UniTask Show(string message)
    {
        // Configure and show the alert
        label.text = message;
        await rootPanel.ScaleTo(Vector3.one,0.25f,EasingEquations.EaseOutBack).Play();
        
        // Wait for user to click Ok
        using (var handler = button.GetAsyncClickEventHandler(this.GetCancellationTokenOnDestroy()))
            await handler.OnClickAsync();
        
        // Dismiss the alert
        await rootPanel.ScaleTo(Vector3.zero, .25f, EasingEquations.EaseInBack).Play();
    }

    private void OnEnable()
    {
        IAlert.Register(this);
        rootPanel.localScale = Vector3.zero;
    }

    private void OnDisable()
    {
        IAlert.Reset();
    }
}

