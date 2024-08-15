using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    public GameObject bulletPrefab;  // Prefab for the bullet
    public int poolSize = 20;        // Maximum number of bullets in the pool
    private Queue<GameObject> bulletPool;

    void Start()
    {
        bulletPool = new Queue<GameObject>();

        // Instantiate the initial set of bullets
        for (int i = 0; i < poolSize; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab);
            bullet.SetActive(false);  // Initially set bullets as inactive
            bulletPool.Enqueue(bullet);
        }
    }

    public GameObject GetPooledBullet()
    {
        // Check if there are any bullets in the pool
        if (bulletPool.Count > 0)
        {
            // Retrieve the oldest bullet from the pool
            GameObject bullet = bulletPool.Dequeue();

            // Reset the bullet (optional, if needed)
            bullet.SetActive(true);
            // Reset bullet properties like position, rotation here if necessary
            bullet.transform.position = Vector3.zero; // Example reset
            bullet.transform.rotation = Quaternion.identity; // Example reset

            // Add the bullet back to the pool after use
            bulletPool.Enqueue(bullet);

            return bullet;
        }
        else
        {
            // If no bullets are available in the pool, instantiate a new one (optional)
            GameObject bullet = Instantiate(bulletPrefab);
            bullet.SetActive(true);
            return bullet;
        }
    }
}
