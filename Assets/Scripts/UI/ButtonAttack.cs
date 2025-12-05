using UnityEngine;
using UnityEngine.UI;

[RequireComponent (typeof(Button))]
public class ButtonAttack : MonoBehaviour
{
    [SerializeField] private HealthComponent _healthComponent;
    [SerializeField] private float _damage;

    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(Attack);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(Attack);
    }

    public void Attack()
    {
        _healthComponent.TakeDamage(_damage);
    }
}