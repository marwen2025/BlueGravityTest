using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DropLoot : MonoBehaviour
{
    [SerializeField] private ItemDefinition _itemDefinition;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private MeshFilter meshFilter;
    //[SerializeField] private Vector3 _forcePower;
    [SerializeField] private bool _canDetectCollision = false;
    public void Initialize(ItemDefinition itemDefinition)
    {
        _itemDefinition = itemDefinition;
        SetItem();
        StartCoroutine(ItemDropColdown());

    }
    private void Start()
    {
        SetItem();
    }
    private IEnumerator ItemDropColdown()
    {

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

    }
    private void OnTriggerEnter(Collider other)
    {
        if (!_canDetectCollision)
        {
            Debug.Log("Connot detect Collision");
            return;
        }

        var inventoryManager = other.gameObject.GetComponentInParent<InventoryManager>();
        Debug.Log($"collinsion Enter {other.gameObject.name}");
        //Debug.Log(inventoryManager.gameObject.name);
        if (inventoryManager != null)
        {
            Debug.Log("Collision Detected");
            inventoryManager.AddItem(_itemDefinition);
            Destroy(gameObject);
        }
    }

}
