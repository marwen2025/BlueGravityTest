using System;
using TMPro;
using Unity.Properties;
using UnityEngine;
using UnityEngine.UI;

public class ItemPopup : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _nameTextMeshPro;
    [SerializeField] private TextMeshProUGUI _descriptionText;
    [SerializeField] private Image _itemImage;
    [SerializeField] private Button _useButton;
    [SerializeField] private Button _cancelButton;
    [SerializeField] private Button _dropButton;
    [SerializeField] private InventoryManager _inventoryManager;
    public Action OnItemUsed;

    public void ShowPopup(ItemInstance itemInstance)
    {
        if (itemInstance != null)
        {
            if (itemInstance.ItemDefinition.FindItemFragment<Weapon_ItemFragment>() != null)
            {
                _useButton.gameObject.SetActive(false);
            }
            else
            {
                _useButton.gameObject.SetActive(true);
            }
        }
        // Set the item description and image
        var itemFragment = itemInstance.ItemDefinition.FindItemFragment<ItemDisplay_ItemFragment>();
        _descriptionText.text = itemFragment.ItemDescription;
        _itemImage.sprite = itemFragment.Image;
        _nameTextMeshPro.text = itemInstance.ItemDefinition.ItemName;
        // Clear previous listeners
        _dropButton.onClick.RemoveAllListeners();
        _useButton.onClick.RemoveAllListeners();
        _cancelButton.onClick.RemoveAllListeners();

        // Set up the Use button
        _useButton.onClick.AddListener(() =>
        {

            _inventoryManager.UseItemOnSelf(itemInstance);
            _inventoryManager.RemoveItem(itemInstance.ItemDefinition);
            gameObject.SetActive(false); // Close the popup
        });

        _dropButton.onClick.AddListener(() =>
        {
            _inventoryManager.DropItem(itemInstance);
            gameObject.SetActive(false); // Close the popup
        });
        // Set up the Cancel button
        _cancelButton.onClick.AddListener(() =>
        {
            gameObject.SetActive(false); // Close the popup 
        });

        // Show the popup
        gameObject.SetActive(true);
    }

    // Hnadling Using Health Potion 

}
