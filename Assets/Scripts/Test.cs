using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public InventoryManager InventoryManager;

    public ItemDefinition ItemDefinition;
    public ItemDefinition ItemDefinition2;
    public void AddItem()
    {
        InventoryManager.AddItem(ItemDefinition);
    }
    public void AddItem2()
    {
        InventoryManager.AddItem(ItemDefinition2);
    }
    public void RemoveItem()
    {
        InventoryManager.RemoveItem(ItemDefinition);
    }
}
