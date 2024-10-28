using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.UI;

public class MenuUI : MonoBehaviour
{
    [SerializeField] private GameManager gamemanager;
    [SerializeField] private FightManager _fightManager;
    [SerializeField] private Button boutonplay;
    [SerializeField] private Button retry;
    [SerializeField] private Button boutonmenu;
    [SerializeField] private Button boutontour;
    [SerializeField] private Button feu;
    [SerializeField] private Button eau;
    [SerializeField] private Button soin;
    [SerializeField] private Button fuite;
    public Animation FireBall;
    public Animation Water;

    public void GoToGame()
    {
        gamemanager.ChangeCurrentState(GameManager.GameState.Game);
    }

    public void GoToMenu()
    {
        gamemanager.ChangeCurrentState(GameManager.GameState.Menu);
    }
    
    public void BTN()
    {
        if (_fightManager.CurrentFightState == FightManager.FightState.Player)
        {
            _fightManager.ChangeTurn(FightManager.FightState.Monster);
        }
        else
        {
            _fightManager.ChangeTurn(FightManager.FightState.Player);
        }
            
    }
    public void fire()
    {
        _fightManager.attack(30, "Monster");
        FireBall.Play();
        _fightManager.ChangeTurn(FightManager.FightState.Monster);
    }
    public void water()
    {
        _fightManager.attack(20, "Monster");
        Water.Play();
        _fightManager.ChangeTurn(FightManager.FightState.Monster);
    }

    public void heal()
    {
        _fightManager.attack(-20, "Player");
        _fightManager.ChangeTurn(FightManager.FightState.Monster);
    }

    public void Retry()
    {
        _fightManager.hpMonster = 100;
        _fightManager.hpPlayer = 100;
        _fightManager.CurrentFightState = FightManager.FightState.Player;
    }
}
