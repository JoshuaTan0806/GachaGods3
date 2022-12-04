using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bench : MonoBehaviour
{
    [SerializeField] List<BenchSpot> team;
    List<BenchSpot> bench = new();

    [SerializeField] CharacterStats characterPreview;
    [SerializeField] Transform benchParent;

    [SerializeField] Vector2 startPos;
    [SerializeField] int numInRow;
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
        for (int i = 0; i < 50; i++)
        {
            Vector3 spawnPos = startPos;

            int currentNumInRow = i % numInRow;
            int currentRow = i / numInRow;

            spawnPos.x += 1.5f * currentNumInRow;
            spawnPos.y -= 1.5f * currentRow;

            BenchSpot s = Instantiate(spotPrefab, spawnPos, Quaternion.identity, benchParent);
            bench.Add(s);
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
