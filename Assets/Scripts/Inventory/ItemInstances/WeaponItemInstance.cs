using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponItemInstance : ItemInstance
{
    private GameObject _spawnedWeapon;

    public WeaponItemInstance(ItemDefinition itemDefinition, Transform playerHand) : base(itemDefinition)
    {
        Weapon_ItemFragment weaponItemFragment = itemDefinition.FindItemFragment<Weapon_ItemFragment>();
        _spawnedWeapon = Object.Instantiate(weaponItemFragment.WeaponPrefab, playerHand);
    }

    public override void OnItemRemoved()
    {
        Object.Destroy(_spawnedWeapon);
        // _spawnedWeapon.SetActive(false);
    }
}