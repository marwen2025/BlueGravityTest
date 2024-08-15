using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public InventoryManager InventoryManager;

    public ItemDefinition ItemDefinition;
    public void AddItem()
    {
        InventoryManager.AddItem(ItemDefinition);
    }

    public void RemoveItem()
    {
        InventoryManager.RemoveItem(ItemDefinition);
    }
}
