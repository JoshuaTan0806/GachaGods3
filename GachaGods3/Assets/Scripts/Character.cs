using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[CreateAssetMenu(menuName = "Character/Character")]
public class Character : ScriptableObject
{
    public Rarity Rarity => rarity;
    [SerializeField] Rarity rarity;

    [Button]
    void QWE()
    {
        for (int i = action.Count - 1; i >= 0; i--)
        {
            AssetDatabase.RemoveObjectFromAsset(action[i]);
            Object.DestroyImmediate(action[i], true);
        }

        UnityEditor.EditorUtility.SetDirty(this);
        UnityEditor.AssetDatabase.SaveAssets();
    }
}