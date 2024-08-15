using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Items/HealthPotion_ItemFragment")]
public class HealthPotion_ItemFragment : ConsumableItem_Fragment
{
    [SerializeField] private float _healthAmount;
    public float HealthAmount => _healthAmount;

    public override void UseItem(IPlayer targetPlayer)
    {
        targetPlayer.HealPlayer(_healthAmount);
    }
}