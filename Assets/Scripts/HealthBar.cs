using UnityEngine;

public abstract class HealthBar : MonoBehaviour
{
    [SerializeField] protected HealthComponent _healthComponent;

    private void OnEnable()
    {
        _healthComponent.ChangedHealth += ShowHealth;
    }

    private void OnDisable()
    {
        _healthComponent.ChangedHealth -= ShowHealth;
    }

    protected abstract void ShowHealth(float health);
}