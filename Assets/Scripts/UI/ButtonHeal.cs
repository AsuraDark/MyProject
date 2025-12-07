using UnityEngine;

public class ButtonHeal : ButtonHealthChanger
{
    [SerializeField] private float _heal;

    protected override void ChangeHealth()
    {
        HealthComponent.Heal(_heal);
    }
}
