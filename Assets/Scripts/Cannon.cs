using UnityEngine;
using UnityEngine.Pool;
using Zenject;

public class Cannon : MonoBehaviour
{
    [SerializeField] new Transform transform;
    [SerializeField] GameObject projectilePrefab;
    public float delayBetweenShots = 1f;

    [Inject] ProjectilePool projectilePool;

    private ObjectPool<Projectile> pool;
    

    private void Start()
    {
        pool = projectilePool.GetPool(projectilePrefab);
    }

    public void Attack()
    {
        pool.Get().Launch(transform.position, transform.up);
    }
}
