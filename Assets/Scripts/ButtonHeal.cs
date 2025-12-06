using UnityEngine;

public class ButtonHeal : ButtonHealthChanger
{
    [SerializeField] private float _heal;

    protected override void ChangeHealth()
    {
        _healthComponent.Heal(_heal);
    }
}
