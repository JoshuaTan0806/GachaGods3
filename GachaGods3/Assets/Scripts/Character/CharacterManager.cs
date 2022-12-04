using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using System.Linq;

[CreateAssetMenu(menuName = "Managers/Character Manager")]
public class CharacterManager : Factories.FactoryBase
{
    [SerializeField] int seed;

    public static List<Character> Characters => characters;
    static List<Character> characters = new List<Character>();
    [SerializeField] List<Character> allCharacters;

    public static List<Rarity> Rarities => rarities;
    static List<Rarity> rarities = new List<Rarity>();
    [SerializeField] List<Rarity> _rarities;

    public static CharacterBlessings CharacterBlessings => characterBlessings;
    static CharacterBlessings characterBlessings = new CharacterBlessings();
    public static List<Character> ActiveCharacters => activeCharacters;
    static List<Character> activeCharacters = new List<Character>();
  
    public static System.Action<Character> OnCharacterPulled;

    public override void Initialise()
    {
        GameManager.OnGameStart -= Clear;
        GameManager.OnGameStart += Clear;

        GameManager.OnGameEnd -= Clear;
        GameManager.OnGameEnd += Clear;

        rarities = _rarities.OrderBy(x => x.RarityNumber).ToList();

        InitialiseCharacters();
    }

    void InitialiseCharacters()
    {
        characters.Clear();

        Random.InitState(seed);

        foreach (var rarity in rarities)
        {
            List<Character> charactersOfRarity = allCharacters.Where(x => x.Rarity == rarity).ToList();

            for (int i = 0; i < 10; i++)
            {
                characters.Add(charactersOfRarity.ChooseRandomElementInList(true));
            }
        }
   
        Random.InitState(System.Environment.TickCount);
    }

    void Clear()
    {
        CharacterBlessings.Clear();
        ActiveCharacters.Clear();
    }

    public static void AddCharacter(Character character)
    {
        if (CharacterBlessings.ContainsKey(character))
        {
            if (CharacterBlessings[character] < CharacterBlessings.Count)
                CharacterBlessings[character]++;
        }
        else
        {
            CharacterBlessings.Add(character, 0);
        }

        OnCharacterPulled?.Invoke(character);
    }

    public static void ActivateCharacter(Character character)
    {
        if (activeCharacters.Contains(character))
            throw new System.Exception("Can't add a character which is already active");
        else
        {
            activeCharacters.Add(character);
        }
    }

    public static void DeactivateCharacter(Character character)
    {
        if (!activeCharacters.Contains(character))
            throw new System.Exception("Can't remove a character that is inactive");
        else
        {
            activeCharacters.Remove(character);
        }
    }

    public static List<Character> TenPull()
    {
        List<Character> c = new();

        //Every 2 rounds, add another rarity to the pool
        List<Character> pullableCharacters = characters.Where(x => x.Rarity.RarityNumber <= 1 + Mathf.FloorToInt(GameManager.RoundNumber / 2)).ToList();

        for (int i = 0; i < 10; i++)
        {
            c.Add(pullableCharacters.ChooseRandomElementInList());
        }

        return c;
    }
}

public class CharacterBlessings : SerializableDictionary<Character, int> { }