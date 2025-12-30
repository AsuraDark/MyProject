using System.Collections;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Attacker : MonoBehaviour
{
    [SerializeField] protected float _delay;
    [SerializeField] private Transform _attackRange;
    [SerializeField] private ObjectPool<Projectile> _pool;

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

    private void Start()
    {
        StartCoroutine(GenerateProjectiles());
    }

    protected IEnumerator GenerateProjectiles()
    {
        var wait = new WaitForSeconds(_delay);

        while (enabled)
        {
            Attack();
            yield return wait;
        }
    }
}
