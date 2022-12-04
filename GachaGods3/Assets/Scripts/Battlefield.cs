using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battlefield : MonoBehaviour
{
    [SerializeField] List<Spot> allyTeam;
    [SerializeField] List<Spot> enemyTeam;

    public Spot ClosestEnemy(Team team)
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

    public Spot FurthestEnemy(Team team)
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
}

public enum Team
{
    Ally,
    Enemy
}
