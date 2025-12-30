using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class BirdAttacker : MonoBehaviour
{
    [SerializeField] private Transform _attackRange;
    [SerializeField] private ObjectPool<Projectile> _pool;
    [SerializeField] private bool _direction;

    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Attack()
    {
        Projectile newObject = _pool.GetObject();
        newObject.ChangeDirection(_spriteRenderer.flipX);

        newObject.gameObject.SetActive(true);
        newObject.transform.position = _attackRange.position;
    }
}
