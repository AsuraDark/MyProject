using UnityEngine;

public class EnemyGenerator : ObjectGenerator<Enemy>
{
    protected override void Spawn()
    {
        float spawnPositionY = Random.Range(_upperBound, _lowerBound);
        Vector3 spawnPoint = new Vector3(transform.position.x, spawnPositionY, transform.position.z);

        Enemy newObject = _pool.GetObject();

        newObject.gameObject.SetActive(true);
        newObject.transform.position = spawnPoint;
    }
}
