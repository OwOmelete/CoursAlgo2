using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class GameManager:MonoBehaviour

    {
        [SerializeField] private GameObject Menu;
        [SerializeField] private GameObject Game;
        
        public enum GameState
        {
            Menu,
            Game
        }

        public GameState m_currentGameState = GameState.Menu;
        
        public void ChangeCurrentState(GameState newGameState)
        {
            switch (m_currentGameState)
            {
                case GameState.Menu:
                    DisableMenu();
                    break;
                case GameState.Game:
                    DisableGame();
                    break;
            }

            m_currentGameState = newGameState;
            switch (newGameState)
            {
                case GameState.Menu: SetUpMenu();
                    break;
                case GameState.Game: SetUpGame();
                    break;
                default: throw new ArgumentOutOfRangeException(nameof(newGameState), newGameState, null);
            }
        }

        
        public void DisableGame()
        {
            Game.SetActive(false);
        }
        
        public void DisableMenu()
        {
            Menu.SetActive(false);
        }
        public void SetUpGame()
        {
            Game.SetActive(true);
        }
        
        public void SetUpMenu()
        {
            Menu.SetActive(true);
        }
    }
}