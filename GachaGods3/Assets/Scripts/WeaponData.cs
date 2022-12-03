using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Character/Appearance/Weapon")]
public class WeaponData : CosmeticData
{
    public const string ID = "Weapon";
    public GameObject LWeaponPrefab => lWeaponPrefab;
    [SerializeField] GameObject lWeaponPrefab;
    public GameObject RWeaponPrefab => rWeaponPrefab;
    [SerializeField] GameObject rWeaponPrefab;
}
