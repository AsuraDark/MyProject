using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class SmoothHealthBar : MonoBehaviour
{
    [SerializeField] private HealthComponent _healthComponent;
    [SerializeField] private float _recoveryRate;

    private Slider _healthSlider;

    private Coroutine _coroutine;

    private void Awake()
    {
        _healthSlider = GetComponent<Slider>();
    }

    private void OnEnable()
    {
        _healthComponent.ChangedHealth += StartChangeHealthBar;
    }

    private void OnDisable()
    {
        _healthComponent.ChangedHealth -= StartChangeHealthBar;
    }

    private void Start()
    {
        _healthSlider.maxValue = _healthComponent.MaxHealth;
        _healthSlider.minValue = _healthComponent.MinHealth;
    }

    private void StartChangeHealthBar(float health)
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }

        _coroutine = StartCoroutine(ChangeHealthBar(health));
    }

    private IEnumerator ChangeHealthBar(float health)
    {
        while (_healthSlider.value != health)
        {
            _healthSlider.value = Mathf.MoveTowards(_healthSlider.value, health, _recoveryRate * Time.deltaTime);
            yield return null;
        }
    }
}