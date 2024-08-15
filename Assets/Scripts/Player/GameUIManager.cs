using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthUIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _healthText;
    [SerializeField] private Player _player;
    [SerializeField] private InventoryManager _inventoryManager;

    private void Start()
    {
        _healthText.text = $"Health: {_player.Health.ToString()}";
    }
    private void OnEnable()
    {
        _inventoryManager.OnItemUsed += UpdateHealthUI;
    }

    private void OnDisable()
    {
        _inventoryManager.OnItemUsed -= UpdateHealthUI;
    }

    private void UpdateHealthUI()
    {
        _healthText.text = $"Health: {_player.Health.ToString()}";
    }
}
