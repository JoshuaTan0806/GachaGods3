using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GachaCard : MonoBehaviour
{
    public Character Character => character;
    Character character;

    public System.Action<GachaCard> OnCardClicked;

    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(() => Select());
    }

    public void Initialise(Character character)
    {
        this.character = character;
    }

    public void Select()
    {
        OnCardClicked?.Invoke(this);
    }
}
