using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PanelManager : MonoBehaviour {
    #region Variables

    [SerializeField] GameObject pausePanel, panelVictory;           // Panel de pausa que se activará y desactivará
    [SerializeField] string menuSceneName = "Menu"; //Menu escena del Menu ;P
    bool isPaused = false;  // Para saber si el juego está en pausa
    bool isPlaying = true;  //si el el usuario aun desea juagr y no cerrar la app
    #endregion Variables

    #region LocalMethods
    void Start() {
        panelVictory.SetActive(false);
        pausePanel.SetActive(false);  // Inicialmente el panel de pausa y victoria esten oculto
    }
    void Update() {

    }

    #endregion Local Methods

    #region Funciones para el panel de pausa
    void OnPause(InputValue value) // Vincula esta función a la acción "Pause" en el Input Actions
   {
        if (isPaused)
            ResumeGame();
        else
            PauseGame();
    }
    // Activa el menú de pausa
    public void PauseGame() {
        isPaused = true;
        pausePanel.SetActive(true);  // Activar el panel de pausa
        Time.timeScale = 0f;         // Detiene el tiempo del juego
    }
    public void ResumeGame() {
        isPaused = false;
        pausePanel.SetActive(false);
        Time.timeScale = 1f;          // Reanuda el tiempo del juego
    }
    // Reinicia el nivel actual
    public void RetryGame() {
        Time.timeScale = 1f;  // indicarle que se reanuda desde el 1er momento del juego
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    // Carga la escena del menú principal
    public void GoToMenu() {
        Time.timeScale = 1f;
        SceneManager.LoadScene(menuSceneName);
    }
    // Salir del juego
    public void GoToExit() {
        // lo mismo pero para el editor, cuando estas en unity
        UnityEditor.EditorApplication.isPlaying = false;
        // para el jugador en in game
        Application.Quit();
    }

    #endregion Funciones para el panel de pausa

    #region Funciones para panel victoria
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player") || collision.CompareTag("Win"))
            if (panelVictory != null) {

                panelVictory = null;
                panelVictory.SetActive(true);
            }
    }

    #endregion Funciones para panel victoria
}
