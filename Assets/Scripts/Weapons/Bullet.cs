using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float deactivateTime = 5f;

    private void OnEnable()
    {
        // Schedule deactivation after a certain time if no collision occurs
        Invoke("Deactivate", deactivateTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Bullet hits");
        // Handle collision and deactivate the bullet
        if (other.CompareTag("NPC") || other.CompareTag("Obstacle"))
        {
            Deactivate();
        }
    }

    private void Deactivate()
    {
        // Deactivate the bullet and remove it from the scene
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        // Cancel the deactivation invoke if the bullet is disabled early due to a collision
        CancelInvoke();
    }
}
