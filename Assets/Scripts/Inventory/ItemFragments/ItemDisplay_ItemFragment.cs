using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Items/ItemDisplay_ItemFragment")]
public class ItemDisplay_ItemFragment : ItemFragment
{
    [SerializeField] private string _itemDescription;
    [SerializeField] private Sprite _image;

    public Sprite Image => _image;
    public string ItemDescription => _itemDescription;
}