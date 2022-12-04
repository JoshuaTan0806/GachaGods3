using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bench : MonoBehaviour
{
    static CharacterStats heldCharacter = null;
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
            if (spot.IsEmpty())
            {
                CharacterStats c = Instantiate(characterPreview, spot.transform);
                c.GetComponent<CharacterAppearance>().Initialise(character);
                c.name = character.name;
                spot.Initialise(c);
                return;
            }
        }
    }

    private void Update()
    {
        HeldCharacterFollowMouse();

        if (Input.GetMouseButtonDown(0))
        {
            CheckForSpot();
        }
    }

    private void CheckForSpot()
    {
        Vector3 pos = Input.mousePosition;
        pos.z = -Camera.main.transform.position.z;

        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(pos), Vector2.zero);

        if (hit.transform == null)
            return;

        Spot spot = hit.transform.GetComponent<Spot>();

        if (spot == null)
            return;

        if (heldCharacter == null)
        {
            if (!spot.IsEmpty())
            {
                heldCharacter = spot.Character;
                spot.Clear();
            }
        }
        else
        {
            if (spot.IsEmpty())
            {
                spot.Initialise(heldCharacter);
                heldCharacter = null;
            }
        }
    }

    void HeldCharacterFollowMouse()
    {
        if (heldCharacter == null)
            return;

        Vector3 pos = Input.mousePosition;
        pos.z = -Camera.main.transform.position.z;

        heldCharacter.transform.position = Camera.main.ScreenToWorldPoint(pos);
    }
}
