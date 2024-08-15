using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DropLoot : MonoBehaviour
{
    [SerializeField] private ItemDefinition _itemDefinition;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Vector3 _forcePower;
    [SerializeField] private bool _canDetectCollision = false;
    private void Start()
    {
        //StartCoroutine(AddForceOverTime());
    }
    public void Initialize(ItemDefinition itemDefinition)
    {
        _itemDefinition = itemDefinition;
        StartCoroutine(AddForceOverTime());
    }
    IEnumerator AddForceOverTime()
    {
        Vector3 force = this.transform.position;
        force += _forcePower;
        rb.AddForce(force, ForceMode.Impulse);
        yield return new WaitForFixedUpdate();
        _canDetectCollision = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!_canDetectCollision)
            return;

        var inventoryManager = collision.gameObject.GetComponentInParent<InventoryManager>();
        Debug.Log($"collinsion Enter {collision.gameObject.name}");
        //Debug.Log(inventoryManager.gameObject.name);
        if (inventoryManager != null)
        {
            Debug.Log("Collision Detected");
            inventoryManager.AddItem(_itemDefinition);
            Destroy(gameObject);
        }
    }

}
