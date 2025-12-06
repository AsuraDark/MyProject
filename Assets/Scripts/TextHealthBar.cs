using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class TextHealthBar : HealthBar
{
    private TextMeshProUGUI _textMeshPro;

    private void Awake()
    {
        _textMeshPro = GetComponent<TextMeshProUGUI>();
    }

    protected override void ShowHealth(float health)
    {
        _textMeshPro.text = new string($"{health}/{_healthComponent.MaxHealth}");
    }
}
