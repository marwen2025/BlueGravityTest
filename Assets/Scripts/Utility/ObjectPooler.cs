using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    [SerializeField] private Transform _bulletsTransform;
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private int _poolSize = 20;
    private Queue<GameObject> _bulletPool;

    void Start()
    {
        _bulletPool = new Queue<GameObject>();

        for (int i = 0; i < _poolSize; i++)
        {
            GameObject bullet = Instantiate(_bulletPrefab, _bulletsTransform);
            bullet.SetActive(false);
            _bulletPool.Enqueue(bullet);
        }
    }

    public GameObject GetPooledBullet()
    {
        // Reuse the oldest bullet in the pool
        GameObject bullet = _bulletPool.Dequeue();

        // If the bullet is still active, you might want to reset its position and other properties here
        if (bullet.activeInHierarchy)
        {
            bullet.SetActive(false);
        }

        // Add it back to the pool after retrieving it
        _bulletPool.Enqueue(bullet);

        return bullet;
    }
}
