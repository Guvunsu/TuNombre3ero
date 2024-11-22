

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace SotomaYorch.DungeonCrawler
{
    #region Enums

    public enum GameStates
    {
        GAME, //= 0
        PAUSE, //= 1
        GAME_OVER, //= 2
        VICTORY
    }

    #endregion

    public class LevelReferee : MonoBehaviour
    {
        #region References

        public GameObject panelPause;
        public GameObject panelGameOver;
        public GameObject panelVictory;

        #endregion

        #region RuntimeVariables

        [SerializeField] protected GameStates _gameState;

        #endregion

        #region UnityMethods
        void Start() //Runtime
        {
            InitializeGameState();
        }

        void FixedUpdate() //Update(): Max 200 FPS / FixedUpdate(): 50 FPS
        {
            switch (_gameState)
            {
                case GameStates.GAME:
                    ExecutingGameState();
                    break;
                case GameStates.GAME_OVER:
                    ExecutingGameOverState();
                    break;
                case GameStates.VICTORY:
                    //ExecutingVictoryState();
                    break;
                case GameStates.PAUSE:
                    ExecutingPauseState();
                    break;
            }
        }

        #endregion

        #region PublicMethods

        public void PauseGame()
        {
            //State Mechanics / Actions to move within the Finite State Machine
            if (_gameState == GameStates.GAME)
            {
                FinalizeGameState();
                //I should go to pause
                _gameState = GameStates.PAUSE;
                InitializePauseState();
            }
            if (_gameState == GameStates.PAUSE)
            {
                FinalizePauseState();
                //I return to the game
                _gameState = GameStates.GAME;
                InitializeGameState();
            }
        }

        public void GameOver()
        {
            if (_gameState != GameStates.GAME)
            {
                FinalizeGameOverState();
                _gameState = GameStates.GAME_OVER;
                InitializeGameOverState();
            }
            if (_gameState == GameStates.GAME_OVER)
            {
                ExecutingGameOverState();
                _gameState = GameStates.GAME_OVER;
                FinalizeGameOverState();
            }
        }

        public void Victory()
        {
            if (_gameState != GameStates.GAME)
            {
                InitializeVictoryState();
                _gameState = GameStates.VICTORY;
                ExecutingVictoryState();
                FinalizeVictoryState();
            }
        }
        #endregion

        #region GameStateMethods

        #region GameState

        protected void InitializeGameState()
        {
            //TODO: Configuration of every aspect of the game
            Time.timeScale = 1f;
        }

        protected void ExecutingGameState()
        {
            //TODO: Manage in runtime several aspects of this state

        }

        protected void FinalizeGameState()
        {
            //TODO: Clean or liberate certain variables from this state
            Time.timeScale = 0f;
            Time.timeScale = Time.timeScale;
            if (_gameState != GameStates.GAME_OVER)
            {
                InitializeVictoryState();
                _gameState = GameStates.GAME;
                ExecutingVictoryState();
                FinalizeVictoryState();
            }
            else
            {
                InitializeVictoryState();
                _gameState = GameStates.VICTORY;
                ExecutingVictoryState();
                FinalizeVictoryState();
            }
        }

        #endregion

        #region PauseState

        protected void InitializePauseState()
        {
            panelPause.SetActive(true);
            Time.timeScale = 0f;
        }

        protected void ExecutingPauseState()
        {
            panelPause.SetActive(true);
            Time.timeScale = 0f;
        }

        protected void FinalizePauseState()
        {
            panelPause.SetActive(false);
            Time.timeScale = 1f;
        }

        #endregion

        #region GameOverState

        protected void InitializeGameOverState()
        {
            panelGameOver.SetActive(true);
            Time.timeScale = 0f;

        }

        protected void ExecutingGameOverState()
        {

        }

        protected void FinalizeGameOverState()
        {
            panelGameOver.SetActive(true);
            Time.timeScale = 1f;
            if (panelGameOver == null)
            {
                panelGameOver.SetActive(_gameState == GameStates.GAME);
                InitializeGameState();
            }
        }

        #endregion GameOverState

        #region VictoryPanel

        protected void InitializeVictoryState()
        {
            //TODO: Configuration of every aspect of the game
            panelVictory.SetActive(true);
            Time.timeScale = 0f;
        }

        protected void ExecutingVictoryState()
        {
            //TODO: Manage in runtime several aspects of this state
        }

        protected void FinalizeVictoryState()
        {
            //TODO: Clean or liberate certain variables from this state
            if (_gameState == GameStates.VICTORY)
            {
                panelVictory?.SetActive(false);
                Time.timeScale = 1f;
            }
        }

        #endregion VictoryPanel

        #endregion GameStateMethods


    }
}

