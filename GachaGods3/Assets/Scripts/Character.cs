using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[CreateAssetMenu(menuName = "Character/Character")]
public class Character : ScriptableObject
{
    public Rarity Rarity => rarity;
    [SerializeField] Rarity rarity;
}