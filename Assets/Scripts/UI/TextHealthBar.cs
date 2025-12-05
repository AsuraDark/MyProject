using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class TextHealthBar : MonoBehaviour
{
    [SerializeField] private HealthComponent _healthComponent;

    private TextMeshProUGUI _textMeshPro;

    private void Awake()
    {
        _textMeshPro = GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        _healthComponent.ChangedHealth += ChangeHealthBar;
    }

    private void OnDisable()
    {
        _healthComponent.ChangedHealth -= ChangeHealthBar;
    }

    private void ChangeHealthBar(float health)
    {
        _textMeshPro.text = new string($"{health}/{_healthComponent.MaxHealth}");
    }
}
