using UnityEngine;

public abstract class TimerBar : MonoBehaviour
{
    [SerializeField] protected CustomTimer _timer;

    private void OnEnable()
    {
        _timer.ChangedTimer += ShowValue;
    }

    private void OnDisable()
    {
        _timer.ChangedTimer -= ShowValue;
    }

    protected abstract void ShowValue(float value);
}