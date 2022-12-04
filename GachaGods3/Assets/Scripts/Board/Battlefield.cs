using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Battlefield : MonoBehaviour
{
    public static Battlefield instance;
    public List<BattlefieldSpot> aliveAlles => allies.Where(x => !x.IsEmpty()).ToList();
    [SerializeField] List<BattlefieldSpot> allies;
    public List<BattlefieldSpot> aliveEnemies => enemies.Where(x => !x.IsEmpty()).ToList();
    [SerializeField] List<BattlefieldSpot> enemies;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    public CharacterStats ClosestEnemy(Team team)
    {
        if (team == Team.Ally)
        {
            if (aliveEnemies.Count == 0)
                return null;

            return aliveEnemies[0].Character;
        }
        else
        {
            if (aliveAlles.Count == 0)
                return null;

            return aliveAlles[0].Character;
        }
    }

    public CharacterStats FurthestEnemy(Team team)
    {
        if (team == Team.Ally)
        {
            if (aliveEnemies.Count == 0)
                return null;

            return aliveEnemies.Last().Character;
        }
        else
        {
            if (aliveAlles.Count == 0)
                return null;

            return aliveAlles.Last().Character;
        }
    }

    public CharacterStats RandomEnemy(Team team)
    {
        if (team == Team.Ally)
        {
            if (aliveEnemies.Count == 0)
                return null;

            return aliveEnemies.ChooseRandomElementInList().Character;
        }
        else
        {
            if (aliveAlles.Count == 0)
                return null;

            return aliveEnemies.ChooseRandomElementInList().Character;
        }
    }
}

public enum Team
{
    Ally,
    Enemy
}
