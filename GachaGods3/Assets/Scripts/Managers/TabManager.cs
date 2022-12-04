using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Tab
{
    Gacha,
    Bench,
    Battlefield
}

public class TabManager : MonoBehaviour
{
    public static TabManager instance;
    [SerializeField] TabDictionary tabs;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    public void SwitchTabs(Tab tab)
    {
        foreach (var t in tabs)
        {
            if (t.Key == tab)
                t.Value.SetActive(true);
            else
                t.Value.SetActive(false);
        }
    }
}

[System.Serializable] public class TabDictionary : SerializableDictionary<Tab, GameObject> { }