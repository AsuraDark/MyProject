using UnityEngine;
using UnityEngine.UI;

[RequireComponent (typeof(Button))]
public class ButtonHeal : MonoBehaviour
{
    [SerializeField] private HealthComponent _healthComponent;
    [SerializeField] private float _heal;

    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(Heal);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(Heal);
    }

    public void Heal()
    {
        _healthComponent.Heal(_heal);
    }
}
