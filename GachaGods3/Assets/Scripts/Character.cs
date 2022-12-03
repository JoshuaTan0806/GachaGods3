using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[CreateAssetMenu(menuName = "Character/Character")]
public class Character : ScriptableObject
{
    public Rarity Rarity => rarity;
    [SerializeField] Rarity rarity;
    public BaseStats BaseStats => baseStats;
    [SerializeField] BaseStats baseStats;
    public List<Blessing> Blessings => blessings;
    [SerializeField] List<Blessing> blessings;
}