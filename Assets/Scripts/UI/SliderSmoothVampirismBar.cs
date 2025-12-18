using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class SliderSmoothVampirismBar : VampirismBar
{
    [SerializeField] private float _recoveryRate;

    private Slider _vampirismSlider;

    private Coroutine _coroutine;

    private void Awake()
    {
        _vampirismSlider = GetComponent<Slider>();
    }

    private void Start()
    {
        _vampirismSlider.maxValue = Vampirism.TimeAction;
        _vampirismSlider.value = _vampirismSlider.maxValue;
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
        while (_vampirismSlider.value != value)
        {
            _vampirismSlider.value = Mathf.MoveTowards(_vampirismSlider.value, value, _recoveryRate * Time.deltaTime);
            yield return null;
        }
    }
}