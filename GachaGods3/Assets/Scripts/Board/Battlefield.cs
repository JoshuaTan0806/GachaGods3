using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battlefield : MonoBehaviour
{
    public static Battlefield instance;
    [SerializeField] List<BattlefieldSpot> allyTeam;
    [SerializeField] List<BattlefieldSpot> enemyTeam;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    public BattlefieldSpot ClosestEnemy(Team team)
    {
        if (team == Team.Ally)
        {
            foreach (var spot in enemyTeam)
            {
                if (!spot.IsEmpty())
                    return spot;
            }
        }
        else
        {
            foreach (var spot in allyTeam)
            {
                if (!spot.IsEmpty())
                    return spot;
            }
        }

        Debug.LogError("Asked for an enemy when they are all dead");
        return null;
    }

    public BattlefieldSpot FurthestEnemy(Team team)
    {
        if (team == Team.Ally)
        {
            for (int i = enemyTeam.Count - 1; i >= 0; i--)
            {
                if (!enemyTeam[i].IsEmpty())
                    return enemyTeam[i];
            }
        }
        else
        {
            for (int i = allyTeam.Count - 1; i >= 0; i--)
            {
                if (!allyTeam[i].IsEmpty())
                    return allyTeam[i];
            }
        }

        Debug.LogError("Asked for an enemy when they are all dead");
        return null;
    }

    public BattlefieldSpot Random(Team team)
    {
        BattlefieldSpot spot = null;
        int counter = 0;

        if (team == Team.Ally)
        {
            while (spot == null)
            {
                spot = enemyTeam.ChooseRandomElementInList();

                if (!spot.IsEmpty())
                    return spot;

                counter++;

                if (counter > 1000)
                    break;
            }
        }
        else
        {
            while (spot == null)
            {
                spot = allyTeam.ChooseRandomElementInList();

                if (!spot.IsEmpty())
                    return spot;

                counter++;

                if (counter > 1000)
                    break;
            }
        }

        Debug.LogError("Asked for an enemy when they are all dead");
        return null;
    }
}

public enum Team
{
    Ally,
    Enemy
}
