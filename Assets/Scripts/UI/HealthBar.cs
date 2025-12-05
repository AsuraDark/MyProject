using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HealthBar : MonoBehaviour
{
    [SerializeField] private HealthComponent _healthComponent;

    private Slider _healthSlider;

    private void Awake()
    {
        _healthSlider = GetComponent<Slider>();
    }

    private void OnEnable()
    {
        _healthComponent.ChangedHealth += ChangeHealthBar;
    }

    private void OnDisable()
    {
        _healthComponent.ChangedHealth -= ChangeHealthBar;
    }

    private void Start()
    {
        _healthSlider.maxValue = _healthComponent.MaxHealth;
        _healthSlider.minValue = _healthComponent.MinHealth;
    }

    private void ChangeHealthBar(float health)
    {
        if (health == 0)
        {
            _healthSlider.value = 0;
            return;
        }

        _healthSlider.value = Mathf.MoveTowards(_healthSlider.value, health, health);
    }
}