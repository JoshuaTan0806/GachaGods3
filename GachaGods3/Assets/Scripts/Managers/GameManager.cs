using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static System.Action OnGameStart;
    public static System.Action OnGameEnd;

    public static System.Action OnPlanningStart;
    public static System.Action OnPlanningEnd;
    public static System.Action OnCombatStart;
    public static System.Action OnCombatEnd;

    public static int RoundNumber => roundNumber;
    static int roundNumber;

    private void Awake()
    {
        roundNumber = 0;
        OnGameStart?.Invoke();
        StartPlanning();
    }

    public static void StartPlanning()
    {
        roundNumber++;
        OnPlanningStart?.Invoke();
    }

    public static void EndPlanning()
    {
        OnPlanningEnd?.Invoke();
    }

    public static void StartCombat()
    {
        OnCombatStart?.Invoke();
    }

    public static void EndCombat()
    {
        OnCombatEnd?.Invoke();
    }
}
