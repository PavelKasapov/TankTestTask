using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class ProjectilePool : MonoBehaviour
{
    [SerializeField] private Transform selfTransform;

    private Dictionary<GameObject, ObjectPool<Projectile>> Pools = new();

    private void CreatePool(GameObject projectilePrefab)
    {
        var Pool = new ObjectPool<Projectile>(
            () => {
                var bullet = Instantiate(projectilePrefab, selfTransform).GetComponent<Projectile>();
                bullet.OnRelease = () => Pools[projectilePrefab].Release(bullet);
                return bullet;
            },
            bullet => bullet.gameObject.SetActive(true),
            bullet => bullet.gameObject.SetActive(false),
            bullet => Destroy(bullet.gameObject),
            true, 10, 20);

        Pools.Add(projectilePrefab, Pool);
    }

    public ObjectPool<Projectile> GetPool(GameObject projectilePrefab)
    {
        if (!Pools.TryGetValue(projectilePrefab, out var pool))
        {
            CreatePool(projectilePrefab);
        }
        return Pools[projectilePrefab];
    }
}