using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class SliderHealthBar : HealthBar
{
    private Slider _healthSlider;

    private void Awake()
    {
        _healthSlider = GetComponent<Slider>();
    }

    private void Start()
    {
        _healthSlider.maxValue = HealthComponent.MaxHealth;
        _healthSlider.minValue = HealthComponent.MinHealth;
        _healthSlider.value = _healthSlider.maxValue;
    }

    protected override void ShowHealth(float health)
    {
        if (health == 0)
        {
            _healthSlider.value = 0;
            return;
        }

        _healthSlider.value = Mathf.MoveTowards(_healthSlider.value, health, health);
    }
}