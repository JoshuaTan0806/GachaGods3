using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spot : MonoBehaviour
{
    [SerializeField] CharacterStats character;

    public void Initialise(CharacterStats character)
    {
        this.character = character;
    }

    protected void Clear()
    {
        character = null;
    }

    public bool IsEmpty()
    {
        return character == null;
    }
}
