using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public List<ItemInstance> InventoryItems { get; private set; }
    [SerializeField] private Player _player;
    public Action<ItemInstance> OnItemAdded;
    public Action<ItemInstance> OnItemRemoved;
    public Action OnItemUsed;
    [SerializeField] private DropLoot _dropLootPrefab;

    private void Awake()
    {
        InventoryItems = new List<ItemInstance>();
    }

    #region Add/Remove

    public ItemInstance AddItem(ItemDefinition itemDefinition)
    {
        ItemInstance itemInstance = CreateItemInstance(itemDefinition);
        InventoryItems.Add(itemInstance);
        OnItemAdded?.Invoke(itemInstance);
        return itemInstance;
    }

    public void RemoveItem(ItemDefinition itemDefinition)
    {
        ItemInstance itemInstanceToRemove = GetItemInstanceByDefinition(itemDefinition);
        RemoveItem(itemInstanceToRemove);
    }

    public void RemoveItem(ItemInstance itemInstance)
    {
        //TODO:Trigger something like unequipped
        if (itemInstance == null)
        {
            return;
        }

        itemInstance.OnItemRemoved();
        OnItemRemoved?.Invoke(itemInstance);
        InventoryItems.Remove(itemInstance);

    }

    #endregion
    public void UseItemOnSelf(ItemInstance itemInstance)
    {
        UseItem(itemInstance.ItemDefinition, _player);
    }
    public void UseItem(ItemDefinition itemDefinition, IPlayer targetPlayer)
    {
        ConsumableItem_Fragment itemFragment = itemDefinition.FindItemFragment<ConsumableItem_Fragment>();
        if (!itemFragment)
        {
            return;
        }
        OnItemUsed?.Invoke();
        itemFragment.UseItem(targetPlayer);
    }

    public ItemInstance GetItemInstanceByDefinition(ItemDefinition itemDefinition)
    {
        foreach (var item in InventoryItems)
        {
            if (item.ItemDefinition == itemDefinition)
            {
                return item;
            }
        }
        return null;
    }

    private ItemInstance CreateItemInstance(ItemDefinition itemDefinition)
    {
        Weapon_ItemFragment weaponItemFragment = itemDefinition.FindItemFragment<Weapon_ItemFragment>();
        if (weaponItemFragment)
        {
            return new WeaponItemInstance(itemDefinition, _player.PlayerHand);
        }

        return new ItemInstance(itemDefinition);
    }
    public void DropItem(ItemInstance itemInstance)
    {
        Vector3 SpawnPosition = this.gameObject.transform.position;
        SpawnPosition.x += 2;
        var dropLoot = Instantiate(_dropLootPrefab, SpawnPosition, Quaternion.identity);
        dropLoot.Initialize(itemInstance.ItemDefinition);
        RemoveItem(itemInstance);
    }
}