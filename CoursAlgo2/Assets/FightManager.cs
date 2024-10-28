using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class FightManager : MonoBehaviour
{
    [SerializeField] private IA ia;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject monster;
    [SerializeField] private GameObject win;
    [SerializeField] private GameObject loose;
    [SerializeField] private GameObject game;
    
    [SerializeField] private TMP_Text PlayerPV;
    [SerializeField] private TMP_Text MonsterPV;
    public float hpPlayer = 100;
    public float hpMonster = 100;
    
    
    public enum FightState
    {
        Player,
        Monster
    }

    public FightState CurrentFightState = FightState.Player;

    public void ChangeTurn(FightState newFightState)
    {
        switch (CurrentFightState)
        {
            case FightState.Player:
                DisablePlayer();
                break;
            case FightState.Monster:
                DisableMonster();
                break;
        }

        CurrentFightState = newFightState;
        switch (newFightState)
        {
            case FightState.Player: SetUpPlayer();
                break;
            case FightState.Monster: SetUpMonster();
                break;
            default: throw new ArgumentOutOfRangeException(nameof(newFightState), newFightState, null);
        }
    }
    public void DisablePlayer()
    {
        player.SetActive(false);
    }
        
    public void DisableMonster()
    {
        monster.SetActive(false);
    }
    public void SetUpPlayer()
    {
        player.SetActive(true);
    }
        
    public void SetUpMonster()
    {
        monster.SetActive(true);
        ia.DetermineState();
        ia.AITurn();
    }
    
    public void attack(int damage, string cible)
    {
        if (cible == "Monster")
        {
            hpMonster -= damage;
            MonsterPV.SetText(hpMonster.ToString());
            if (hpMonster <= 0)
            {
                player.SetActive(false);
                monster.SetActive(false);
                game.SetActive(false);
                win.SetActive(true);
            }
        }
        if(cible == "Player")
        {
            hpPlayer -= damage;
            PlayerPV.SetText(hpPlayer.ToString());
            if (hpPlayer <= 0)
            {
                player.SetActive(false);
                monster.SetActive(false);
                game.SetActive(false);
                loose.SetActive(true);
            }
        }
    }

    

}
