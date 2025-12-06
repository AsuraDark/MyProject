using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class SliderSmoothHealthBar : HealthBar
{
    [SerializeField] private float _recoveryRate;

    private Slider _healthSlider;

    private Coroutine _coroutine;

    private void Awake()
    {
        _healthSlider = GetComponent<Slider>();
    }

    private void Start()
    {
        _healthSlider.maxValue = _healthComponent.MaxHealth;
        _healthSlider.minValue = _healthComponent.MinHealth;
        _healthSlider.value = _healthSlider.maxValue;
    }

    protected override void ShowHealth(float health)
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }

        _coroutine = StartCoroutine(ChangeValue(health));
    }

    private IEnumerator ChangeValue(float health)
    {
        while (_healthSlider.value != health)
        {
            _healthSlider.value = Mathf.MoveTowards(_healthSlider.value, health, _recoveryRate * Time.deltaTime);
            yield return null;
        }
    }
}