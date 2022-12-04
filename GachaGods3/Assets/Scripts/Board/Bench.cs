using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bench : MonoBehaviour
{
    List<BenchSpot> bench = new();

    [SerializeField] CharacterStats characterPreview;

    [SerializeField] Vector2Int spotsX = new();
    [SerializeField] Vector2Int spotsY = new();
    [SerializeField] BenchSpot spotPrefab;

    private void OnEnable()
    {
        CharacterManager.OnCharacterPulled += SpawnCharacter;
    }

    private void OnDisable()
    {
        CharacterManager.OnCharacterPulled -= SpawnCharacter;
    }

    void Start()
    {
        for (int j = spotsY.x - 1; j >= spotsY.y; j--)
        {
            for (int i = spotsX.x; i < spotsX.y + 1; i++)
            {
                BenchSpot s = Instantiate(spotPrefab, new Vector3(i, j, 0), Quaternion.identity, transform);
                bench.Add(s);
            }
        }
    }

    void SpawnCharacter(Character character)
    {
        if (CharacterManager.CharacterBlessings[character] != 0)
            return;

        foreach (var spot in bench)
        {
            if(spot.IsEmpty())
            {
                CharacterStats c = Instantiate(characterPreview, spot.transform);
                c.GetComponent<CharacterAppearance>().Initialise(character);
                c.name = character.name;
                spot.Initialise(c);
                return;
            }
        }
    }
}
