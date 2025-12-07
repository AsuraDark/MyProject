using UnityEngine;

public abstract class HealthBar : MonoBehaviour
{
    [SerializeField] protected HealthComponent HealthComponent;

    private void OnEnable()
    {
        HealthComponent.ChangedHealth += ShowHealth;
    }

    private void OnDisable()
    {
        HealthComponent.ChangedHealth -= ShowHealth;
    }

    protected abstract void ShowHealth(float health);
}