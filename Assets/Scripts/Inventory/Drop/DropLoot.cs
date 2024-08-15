using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DropLoot : MonoBehaviour
{
    [SerializeField] private ItemDefinition _itemDefinition;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private MeshFilter meshFilter;
    [SerializeField] private Vector3 _forcePower;
    [SerializeField] private bool _canDetectCollision = false;
    public void Initialize(ItemDefinition itemDefinition)
    {
        _itemDefinition = itemDefinition;
        SetItem();
        StartCoroutine(AddForceOverTime());
    }
    private void Start()
    {
        SetItem();
        //StartCoroutine(AddForceOverTime());
    }
    private IEnumerator AddForceOverTime()
    {
        Vector3 force = this.transform.position;
        force += _forcePower;
        rb.AddForce(force, ForceMode.Impulse);
        yield return new WaitForSeconds(0.2f);
        _canDetectCollision = true;
    }
    private void SetItem()
    {
        if (_itemDefinition == null)
        {
            return;
        }

        Droppable_ItemFragment droppable_ItemFragment = _itemDefinition.FindItemFragment<Droppable_ItemFragment>();
        if (droppable_ItemFragment == null)
            return;

        meshFilter.mesh = droppable_ItemFragment.DroppedItemMesh;
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
