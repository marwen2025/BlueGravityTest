using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class Gun : MonoBehaviour
{
    [SerializeField] private Transform FirePoint;
    [SerializeField] private float BulletForce = 20f;
    [SerializeField] private ObjectPooler _objectPooler;
    [SerializeField] private GameInput _gameInput;
    [SerializeField] private Player _player;

    private void Awake()
    {
        _objectPooler = FindObjectOfType<ObjectPooler>();
        _gameInput = FindObjectOfType<GameInput>();
        _player = FindObjectOfType<Player>();
    }
    private void OnEnable()
    {
        _gameInput.OnFireAction += GameInput_OnFireAction;
    }

    private void OnDisable()
    {
        _gameInput.OnFireAction -= GameInput_OnFireAction;
    }

    private void GameInput_OnFireAction(object sender, EventArgs e)
    {
        //Debug.Log("Key Shoot pressed");
        Shoot();
    }

    void Shoot()
    {
        // Get a bullet from the object pool
        GameObject bullet = _objectPooler.GetPooledBullet();

        // Set the bullet's position to the firePoint
        bullet.transform.position = FirePoint.position;

        // Set the bullet's direction based on the player's forward direction
        bullet.transform.forward = _player.transform.forward;

        // Activate the bullet
        bullet.SetActive(true);

        // Apply force to the bullet in the direction the player is looking
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.velocity = bullet.transform.forward * BulletForce;
    }
}
