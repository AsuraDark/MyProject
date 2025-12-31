using System.Collections;
using UnityEngine;

[RequireComponent(typeof(ProjectileSpawnerAutomatic))]
public class Attacker : MonoBehaviour
{
    private ProjectileSpawnerAutomatic _projectileGenerator;

    private void Awake()
    {
        _projectileGenerator = GetComponent<ProjectileSpawnerAutomatic>();
    }

    private void OnEnable()
    {
        StartAttack();
    }
    private void OnDisable()
    {
        StopAttack();
    }

    public void StartAttack()
    {
        _projectileGenerator.StartSpawn();
    }

    public void StopAttack()
    {
        _projectileGenerator.StopSpawn();
    }
}
