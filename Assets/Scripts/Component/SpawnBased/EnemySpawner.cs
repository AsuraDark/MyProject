using System.Collections;
using UnityEngine;

public class EnemySpawner : Spawner<Enemy>
{
    [SerializeField] protected float _lowerBound;
    [SerializeField] protected float _upperBound;

    Coroutine _coroutine;

    private void OnEnable()
    {
        if(_coroutine == null )
        {
            _coroutine = StartCoroutine(GenerateEnemies());
        }
    }

    private void OnDisable()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }
    }

    private void Awake()
    {
        Pool = new ObjectPool<Enemy>();
        Pool.Init();
    }

    protected IEnumerator GenerateEnemies()
    {
        var wait = new WaitForSeconds(Delay);

        while (enabled)
        {
            Spawn();
            yield return wait;
        }
    }

    public override void Spawn()
    {
        float spawnPositionY = Random.Range(_upperBound, _lowerBound);
        Vector3 spawnPoint = new Vector3(transform.position.x, spawnPositionY, transform.position.z);

        Enemy newObject;

        if (Pool.Length == 0 )
        {
            newObject = Instantiate(Prefab);
            newObject.ObjectDestroyed += OnDestroyObject;
        }
        else
        {
            newObject = Pool.GetObject();
            newObject.ObjectDestroyed += OnDestroyObject;
        }

        newObject.gameObject.SetActive(true);
        newObject.transform.position = spawnPoint;
    }

    private void OnDestroyObject(Enemy enemy)
    {
        enemy.gameObject.SetActive(false);
        enemy.ObjectDestroyed -= OnDestroyObject;

        Pool.PutObject(enemy);
    }
}
