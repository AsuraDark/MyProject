using UnityEngine;

public class ProjectileSpawner : Spawner<Projectile>
{
    [SerializeField] private Transform _spawnPosition;

    private void Awake()
    {
        Pool = new ObjectPool<Projectile>();
        Pool.Init();
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
}
