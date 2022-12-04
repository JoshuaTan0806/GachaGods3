using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattlefieldSpot : Spot
{
    private void OnEnable()
    {
        GameManager.OnCombatEnd += Clear;
    }

    private void OnDisable()
    {
        GameManager.OnCombatEnd -= Clear;
    }
}
