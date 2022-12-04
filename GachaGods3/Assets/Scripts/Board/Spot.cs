using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spot : MonoBehaviour
{
    //neeed to change to characterstats
    [SerializeField] Character character;

    private void OnEnable()
    {
        GameManager.OnCombatEnd += Clear;
    }

    private void OnDisable()
    {
        GameManager.OnCombatEnd -= Clear;
    }

    void Initialise(Character character)
    {
        this.character = character;
    }

    void Clear()
    {
        character = null;
    }

    public bool IsEmpty()
    {
        return character == null;
    }
}
