using UnityEngine;

public abstract class VampirismBar : MonoBehaviour
{
    [SerializeField] protected Vampirism Vampirism;

    private void OnEnable()
    {
        Vampirism.ChangedTimer += ShowValue;
    }

    private void OnDisable()
    {
        Vampirism.ChangedTimer -= ShowValue;
    }

    protected abstract void ShowValue(float health);
}