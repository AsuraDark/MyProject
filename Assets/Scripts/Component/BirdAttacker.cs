using UnityEngine;

[RequireComponent (typeof(ProjectileSpawner))]
public class BirdAttacker : MonoBehaviour
{
    private ProjectileSpawner _projectileGenerator;

    private void Awake()
    {
        _projectileGenerator = GetComponent<ProjectileSpawner>();
    }

    public void Attack()
    {
        _projectileGenerator.Spawn();
    }
}
