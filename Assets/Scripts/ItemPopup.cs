using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemPopup : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _descriptionText;
    [SerializeField] private Image _itemImage;
    [SerializeField] private Button _useButton;
    [SerializeField] private Button _cancelButton;

    private void Awake()
    {
        // Ensure the popup is initially hidden
        gameObject.SetActive(false);
    }

    public void ShowPopup(ItemInstance itemInstance)
    {
        // Set the item description and image
        var itemFragment = itemInstance.ItemDefinition.FindItemFragment<ItemDisplay_ItemFragment>();
        _descriptionText.text = itemFragment.ItemDescription;
        _itemImage.sprite = itemFragment.Image;

        // Clear previous listeners
        _useButton.onClick.RemoveAllListeners();
        _cancelButton.onClick.RemoveAllListeners();

        // Set up the Use button
        _useButton.onClick.AddListener(() =>
        {
            // Implement the use item logic here
            // UseItem(inventoryItem);
            gameObject.SetActive(false); // Close the popup
        });

        // Set up the Cancel button
        _cancelButton.onClick.AddListener(() =>
        {
            gameObject.SetActive(false); // Close the popup without using the item
        });

        // Show the popup
        gameObject.SetActive(true);
    }
}
