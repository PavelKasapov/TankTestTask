using UnityEngine;
using Zenject;

public class SceneInstaller : MonoInstaller
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private EnemyMovementSystem enemyMovementSystem;
    [SerializeField] private ProjectilePool projectilePool;
    [SerializeField] private GameObject enemyPrefab;
    public override void InstallBindings()
    {
        Container.BindInstance(playerTransform).WithId("PlayerTransform");
        Container.BindInstance(enemyMovementSystem);
        Container.BindInstance(projectilePool);
        Container.BindFactory<Enemy, Enemy.Factory>().FromComponentInNewPrefab(enemyPrefab);
    }
}