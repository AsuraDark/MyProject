using JetBrains.Annotations;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerCollectableItems : MonoBehaviour
{
    [SerializeField] private List<CollectableItem> items;

    [SerializeField][Range(0, 5)] private float _rangeSpawn;

    private void Start()
    {
        for (int i = 0; i < items.Count; i++)
        {
            Vector3 position = new Vector3(
                Random.Range(transform.position.x - _rangeSpawn, transform.position.x + _rangeSpawn),
                Random.Range(transform.position.y - _rangeSpawn, transform.position.y + _rangeSpawn),
                Random.Range(transform.position.z - _rangeSpawn, transform.position.z + _rangeSpawn));

            CollectableItem item = Instantiate(items[i], position, items[i].transform.rotation);
            item.CollectedItem += DestroyItem;
        }
    }

    public void DestroyItem(CollectableItem item)
    {
        Destroy(item.gameObject);
    }
}
