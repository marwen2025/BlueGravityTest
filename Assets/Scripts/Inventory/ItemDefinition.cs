using System.Collections;
using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(menuName = "Items/ItemDefinition")]
public class ItemDefinition : ScriptableObject
{
    [SerializeField] private string _itemName;
    [SerializeField] private List<ItemFragment> _itemFragments;

    public string ItemName => _itemName;
    public List<ItemFragment> ItemFragments => _itemFragments;

    public T FindItemFragment<T>() where T : ItemFragment
    {
        foreach (ItemFragment Item in ItemFragments)
        {
            if (Item is T)
            {
                return (T)Item;
            }
        }

        return null;
    }
}