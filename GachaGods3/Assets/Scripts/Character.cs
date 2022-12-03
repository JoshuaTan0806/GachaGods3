using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Character/Character")]
public class Character : ScriptableObject
{
    public Rarity Rarity => rarity;
    [SerializeField] Rarity rarity;
}