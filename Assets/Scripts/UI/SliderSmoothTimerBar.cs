using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class SliderSmoothTimerBar : TimerBar
{
    [SerializeField] private float _recoveryRate;

    private Slider _timerSlider;

    private Coroutine _coroutine;

    private void Awake()
    {
        _timerSlider = GetComponent<Slider>();
    }

    private void Start()
    {
        _timerSlider.maxValue = _timer.TimeAction;
        _timerSlider.value = _timerSlider.maxValue;
    }

    protected override void ShowValue(float health)
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }

        _coroutine = StartCoroutine(ChangeValue(health));
    }

    private IEnumerator ChangeValue(float value)
    {
        while (_timerSlider.value != value)
        {
            _timerSlider.value = Mathf.MoveTowards(_timerSlider.value, value, _recoveryRate * Time.deltaTime);
            yield return null;
        }
    }
}