using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUIManager : MonoBehaviour
{
    struct InventoryItem
    {
        public ItemInstance ItemInstance;
        public GameObject ItemUI;
    }
    [SerializeField] Transform _inventoryHolder;
    [SerializeField] InventoryManager _inventoryManager;
    [SerializeField] GameObject _itemUIPrefab;
    private List<InventoryItem> _inventoryItems = new List<InventoryItem>();
    private void Awake()
    {
        _inventoryManager.OnItemAdded += AddItemToInventory;
    }
    private void OnDestroy()
    {
        _inventoryManager.OnItemAdded -= AddItemToInventory;
    }

    void AddItemToInventory(ItemInstance item)
    {
        var itemDisplay = item.ItemDefinition.FindItemFragment<ItemDisplay_ItemFragment>();
        if (itemDisplay != null)
        {
            var itemUI = Instantiate(_itemUIPrefab, _inventoryHolder);
            InventoryItem inventoryItem = new InventoryItem();
            inventoryItem.ItemInstance = item;
            inventoryItem.ItemUI = itemUI;
            itemUI.GetComponent<Image>().sprite = itemDisplay.Image;
            _inventoryItems.Add(inventoryItem);
        }
    }




}
