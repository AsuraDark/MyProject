using UnityEngine;

public abstract class HealthBar : MonoBehaviour
{
    [SerializeField] protected HealthComponent HealthComponent;

    private void OnEnable()
    {
        HealthComponent.ChangedValue += ShowHealth;
    }

    private void OnDisable()
    {
        HealthComponent.ChangedValue -= ShowHealth;
    }

    protected abstract void ShowHealth(float health);
}