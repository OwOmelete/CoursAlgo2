using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class IA : MonoBehaviour
{
    [SerializeField] private FightManager _fightManager;
    public enum AIState
    {
        loosing,
        winning
    }

    public AIState currentState = AIState.winning;

    public void DetermineState()
    {
        currentState = _fightManager.hpPlayer - _fightManager.hpMonster > 30 ? AIState.loosing : AIState.winning;
    }
    
    public void AITurn()
    {
        switch (currentState)
        {
            case AIState.loosing: ManageLoosing();
                break;
            case AIState.winning: ManageWinning();
                break;
            default: throw new ArgumentOutOfRangeException();    
        }
    }

    public void ManageLoosing()
    {
        var rand = Random.Range(0, 100);
        if (rand > 90)
        {
            //flee
            return;
        }

        if (rand > 35)
        {
            _fightManager.attack(-20, "Monster");
        }
        _fightManager.attack(20, "Player");
    }

    public void ManageWinning()
    {
        var rand = Random.Range(0, 100);
        if (rand > 85)
        {
            _fightManager.attack(35, "Player");
        }
        _fightManager.attack(20, "Player");
    }
}
