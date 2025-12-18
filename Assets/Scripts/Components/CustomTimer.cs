using System;
using System.Collections;
using UnityEngine;

public class CustomTimer : MonoBehaviour
{
    [SerializeField] private float _timeAction;
    [SerializeField] private float _recoveryRate;

    private float _timer;
    private float _recoveryRateModificator;

    private bool _isReady = true;

    Coroutine _coroutine;

    public event Action<float> ChangedTimer;
    public event Action StartedTimer;
    public event Action StoppedTimer;

    public float Timer
    {
        get { return _timer; }
    }

    public float TimeAction
    {
        get { return _timeAction; }
    }

    private void Start()
    {
        _timer = _timeAction;
        _recoveryRateModificator = _timeAction / _recoveryRate;
    }

    public void StartTimer()
    {
        if(_isReady == true)
        {
            if (_coroutine != null)
            {
                StopCoroutine(_coroutine);
            }

            _coroutine = StartCoroutine(ChangeValue());
            _isReady = false;

            StartedTimer?.Invoke();
        }
    }

    private IEnumerator ChangeValue()
    {
        while (enabled && _timer >= 0)
        {
            _timer -= Time.deltaTime;
            ChangedTimer?.Invoke(_timer);

            yield return null;
        }

        StoppedTimer?.Invoke();

        while (enabled && _timer <= _timeAction)
        {
            _timer += Time.deltaTime * _recoveryRateModificator;
            ChangedTimer?.Invoke(_timer);

            yield return null;
        }

        _isReady = true;
    }
}
