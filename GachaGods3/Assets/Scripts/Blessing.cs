using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[CreateAssetMenu(menuName = "Character/Blessing")]
public class Blessing : ScriptableObject
{
#if UNITY_EDITOR
    [Button]
    void DestroyScriptable()
    {
        DestroyImmediate(this, true);
    }
#endif
}
