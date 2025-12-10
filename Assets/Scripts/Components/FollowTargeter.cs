using System.Collections;
using UnityEngine;

public class FollowTargeter : MonoBehaviour
{
    [SerializeField] private float _speed;

    public IEnumerator StartFollowTarget(Vector3 target)
    {
        while (enabled)
        {
            Vector3 direction = ChangeDirection(target);

            transform.Translate(_speed * Time.deltaTime * direction);
            yield return null;
        }
    }

    private Vector3 ChangeDirection(Vector3 target)
    {
        return (target - transform.position).normalized;
    }
}
