using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class InventoryUIManager : MonoBehaviour
{


    [SerializeField] Transform _inventoryHolder;
    [SerializeField] InventoryManager _inventoryManager;
    [SerializeField] GameObject _itemUIPrefab;
    [SerializeField] private ItemPopup _itemPopup;

    [SerializeField] private List<InventoryItem> _inventoryItems = new List<InventoryItem>();
    private Queue<GameObject> _uiPool = new Queue<GameObject>();

    private void Awake()
    {
        _inventoryManager.OnItemAdded += AddItemToInventory;
        _inventoryManager.OnItemRemoved += RemoveItemFromInventory; // Assuming there's an event for removing items
    }

    private void OnDestroy()
    {
        _inventoryManager.OnItemAdded -= AddItemToInventory;
        _inventoryManager.OnItemRemoved -= RemoveItemFromInventory; // Unsubscribe to prevent memory leaks
    }

    private void AddItemToInventory(ItemInstance item)
    {
        var itemDisplay = item.ItemDefinition.FindItemFragment<ItemDisplay_ItemFragment>();
        if (itemDisplay != null)
        {
            GameObject itemUI = Instantiate(_itemUIPrefab, _inventoryHolder);

            InventoryItem inventoryItem = new InventoryItem
            {
                ItemInstance = item,
                ItemUI = itemUI
            };

            itemUI.GetComponent<Image>().sprite = itemDisplay.Image;
            _inventoryItems.Add(inventoryItem);

            // Attach the ShowPopup method to the button's onClick event
            Button itemButton = itemUI.GetComponent<Button>();
            itemButton.onClick.RemoveAllListeners();
            itemButton.onClick.AddListener(() => _itemPopup.ShowPopup(inventoryItem.ItemInstance));
        }
    }
    void RemoveItemFromInventory(ItemInstance item)
    {
        // Find the item in the list
        var inventoryItem = _inventoryItems.Find(i => i.ItemInstance == item);
        if (inventoryItem.ItemUI != null)
        {
            // Deactivate the UI element and add it back to the pool
            inventoryItem.ItemUI.SetActive(false);
            _uiPool.Enqueue(inventoryItem.ItemUI);

            // Remove the item from the inventory list
            _inventoryItems.Remove(inventoryItem);

        }
    }


}
[Serializable]
public struct InventoryItem
{
    public ItemInstance ItemInstance;
    public GameObject ItemUI;
}


