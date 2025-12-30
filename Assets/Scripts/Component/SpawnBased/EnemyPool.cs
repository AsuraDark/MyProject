public class EnemyPool : ObjectPool<Enemy>
{
    public override Enemy GetObject()
    {
        Enemy enemy;

        if (_pool.Count == 0)
        {
            enemy = Instantiate(_prefab);
            enemy.ObjectDestroyed += PutObject;

            return enemy;
        }

        enemy = _pool.Dequeue();
        enemy.ObjectDestroyed += PutObject;

        return enemy;
    }

    public override void PutObject(Enemy enemy)
    {
        _pool.Enqueue(enemy);
        enemy.gameObject.SetActive(false);
        enemy.ObjectDestroyed -= PutObject;
    }
}
