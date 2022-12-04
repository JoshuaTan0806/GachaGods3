using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spot : MonoBehaviour
{
    public CharacterStats Character => character;
    [SerializeField] CharacterStats character;

    public void Initialise(CharacterStats character)
    {
        this.character = character;
        character.transform.SetParent(transform);
        character.transform.localPosition = Vector3.zero;
    }

    public void Clear()
    {
        character = null;
    }

    public bool IsEmpty()
    {
        return character == null;
    }
}
