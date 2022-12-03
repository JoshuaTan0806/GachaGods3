using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[CreateAssetMenu(menuName = "Character/Attack")]
public class AbilityData : ScriptableObject
{
    //public Ability Prefab => prefab;
    //[SerializeField] Ability prefab;

    public string Description => description;
    [SerializeField] string description;

    public string AnimationName => animationName;
    [SerializeField] string animationName;

    public int NumTargets => numTargets;
    [SerializeField, Min(1)] int numTargets = 1;

    public TeamType TeamType => teamType;
    [SerializeField] TeamType teamType = TeamType.Enemy;

    public TargetType TargetType => targetType;
    [SerializeField] TargetType targetType;

#if UNITY_EDITOR
    [Button]
    void DestroyScriptable()
    {
        DestroyImmediate(this, true);
    }
#endif
}

public enum TeamType
{
    Ally,
    Enemy
}

public enum TargetType
{
    Front,
    Back,
    Random,
    AOE
}