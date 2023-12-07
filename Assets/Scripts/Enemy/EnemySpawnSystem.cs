using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Pool;
using Zenject;

public class EnemySpawnSystem : MonoBehaviour
{
    [Inject] private Enemy.Factory enemyFactory;
    [SerializeField] private EnemyParameters[] enemyParameters;

    private ObjectPool<Enemy> enemies;

    void Start()
    {
        enemies = new ObjectPool<Enemy>(
            Create, 
            enemy => enemy.gameObject.SetActive(true),
            enemy => {
                enemy.gameObject.SetActive(false);
                Spawn();
            },
            null, 
            false, 10, 10);;

        for(int i = 0; i < 10; i++)
        {
            Spawn();
        }
    }

    private Enemy Create()
    {
        var newEnemy = enemyFactory.Create();
        newEnemy.transform.parent = transform;
        return newEnemy;
    }

    private void Spawn()
    {
        var parameters = enemyParameters[UnityEngine.Random.Range(0, enemyParameters.Length)];
        var enemy = enemies.Get();
        enemy.SetParameters(parameters);
        enemy.HpSystem.OnDeath = () => enemies.Release(enemy);
        var spawnDirection = UnityEngine.Random.Range(0, 360);
        enemy.transform.position = new Vector3(Mathf.Sin(spawnDirection) * 20, Mathf.Cos(spawnDirection) * 20, 0);

    }
}
