using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using UnityEditor;

[CreateAssetMenu(menuName = "Character/Character")]
public class Character : ScriptableObject
{
    public Rarity Rarity => rarity;
    [SerializeField] Rarity rarity;
    public BaseStats BaseStats => baseStats;
    [SerializeField] BaseStats baseStats;
    public List<Trait> Traits => traits;
    [SerializeField] List<Trait> traits;
    public List<Blessing> Blessings => blessings;
    [SerializeField] List<Blessing> blessings;
    public List<AbilityData> Abilities => abilities;
    [SerializeField] List<AbilityData> abilities;

    public AppearanceData Appearance => appearance;
    [SerializeField] AppearanceData appearance;

#if UNITY_EDITOR

    [Button]
    void RandomiseStats()
    {
        foreach (var stat in StatManager.StatDictionary)
        {
            if (baseStats.ContainsKey(stat.Key))
                baseStats[stat.Key] = Random.Range(0, 100);
            else
                baseStats.Add(stat.Key, Random.Range(0, 100));
        }
    }

    [Button]
    void CreateBlessings()
    {
        for (int i = 0; i < 10; i++)
        {
            Blessing blessing = ScriptableObject.CreateInstance<Blessing>();
            blessing.name = "Blessing " + (i + 1);
            blessings.Add(blessing);

            AssetDatabase.AddObjectToAsset(blessing, this);
        }
        EditorExtensionMethods.SaveAsset(this);
    }

    [Button]
    void CreateAppearance()
    {
        AppearanceData appearance = ScriptableObject.CreateInstance<AppearanceData>();
        appearance.name = "Appearance";
        this.appearance = appearance;
        AssetDatabase.AddObjectToAsset(appearance, this);

        EditorExtensionMethods.SaveAsset(this);
    }

    [Button]
    void CreateAbility()
    {
        AbilityData ability = ScriptableObject.CreateInstance<AbilityData>();
        ability.name = "Ability " + (abilities.Count + 1);
        abilities.Add(ability);
        AssetDatabase.AddObjectToAsset(ability, this);
    }
#endif
}