using UnityEngine;

public class ObjectRemover : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Enemy enemy))
        {
            enemy.DestroyObject(enemy);
        }

        else if (other.TryGetComponent(out Projectile projectile))
        {
            projectile.DestroyObject(projectile);
        }
    }
}