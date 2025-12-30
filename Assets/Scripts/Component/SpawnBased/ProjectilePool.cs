public class ProjectilePool : ObjectPool<Projectile>
{
    public override Projectile GetObject()
    {
        Projectile projectile;

        if (_pool.Count == 0)
        {
            projectile = Instantiate(_prefab);
            projectile.ObjectDestroyed += PutObject;

            return projectile;
        }

        projectile = _pool.Dequeue();
        projectile.ObjectDestroyed += PutObject;

        return projectile;
    }

    public override void PutObject(Projectile newObject)
    {
        _pool.Enqueue(newObject);
        newObject.gameObject.SetActive(false);
        newObject.ObjectDestroyed -= PutObject;
    }
}
