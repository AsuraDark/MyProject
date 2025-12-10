using System;
using UnityEngine;

public class CollectableItem : MonoBehaviour
{
    [SerializeField] private ItemType _itemType;
    [SerializeField] private float _value;

    public event Action<CollectableItem> CollectedItem;

    public ItemType ItemType { get { return _itemType; } }
    public float Value { get { return _value; } }

    public void Collect()
    {
        CollectedItem?.Invoke(this);
    }
}

[Serializable]
public enum ItemType
{
    Coin,
    FirstAidKit
}
