using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// [CreateAssetMenu(menuName = "Items/ItemFragment")]
public abstract class ItemFragment : ScriptableObject
{
    
}
public abstract class ConsumableItem_Fragment : ItemFragment
{
    public abstract void UseItem(IPlayer targetPlayer);
}