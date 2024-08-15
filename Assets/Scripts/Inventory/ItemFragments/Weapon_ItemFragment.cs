using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Items/Weapon_ItemFragment")]
public class Weapon_ItemFragment : ItemFragment
{
    [SerializeField] private int magazineSize;
    [SerializeField] private int maxAmmoCapacity;

    [SerializeField] private GameObject weaponPrefab;

    public GameObject WeaponPrefab => weaponPrefab;

}
