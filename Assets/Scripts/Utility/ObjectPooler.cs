using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    public GameObject bulletPrefab;
    public int poolSize = 20;
    private Queue<GameObject> bulletPool;

    void Start()
    {
        bulletPool = new Queue<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab);
            bullet.SetActive(false);
            bulletPool.Enqueue(bullet);
        }
    }

    public GameObject GetPooledBullet()
    {
        // Reuse the oldest bullet in the pool
        GameObject bullet = bulletPool.Dequeue();

        // If the bullet is still active, you might want to reset its position and other properties here
        if (bullet.activeInHierarchy)
        {
            bullet.SetActive(false);
        }

        // Add it back to the pool after retrieving it
        bulletPool.Enqueue(bullet);

        return bullet;
    }
}
