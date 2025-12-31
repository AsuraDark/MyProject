using System.Collections;
using UnityEngine;

public class ProjectileSpawnerAutomatic : Spawner<Projectile>
{
    [SerializeField] private Transform _spawnPosition;

    Coroutine _coroutine;

    private void Awake()
    {
        if( Pool != null )
        {
            Pool = new ObjectPool<Projectile>();
            Pool.Init();
        }
    }

    public void StartSpawn()
    {
        if (_coroutine == null)
        {
            if (Pool == null)
            {
                Pool = new ObjectPool<Projectile>();
                Pool.Init();
            }

            _coroutine = StartCoroutine(GenerateProjectiles());
        }
    }

    public void StopSpawn()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }
    }

    public override void Spawn()
    {
        Projectile newObject;

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
        newObject.ChangeRotation(transform.eulerAngles.y);
        newObject.transform.position = _spawnPosition.position;
    }

    private void OnDestroyObject(Projectile projectile)
    {
        projectile.gameObject.SetActive(false);
        projectile.ObjectDestroyed -= OnDestroyObject;

        Pool.PutObject(projectile);
    }

    private IEnumerator GenerateProjectiles()
    {
        var wait = new WaitForSeconds(Delay);

        while (enabled)
        {
            Spawn();
            yield return wait;
        }
    }
}
