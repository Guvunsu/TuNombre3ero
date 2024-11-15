//using System.Collections;
//using System.Collections.Generic;
//using TMPro; // Para el TextMeshProUGUI
//using Unity.VisualScripting.Antlr3.Runtime;
//using UnityEngine;
//using UnityEngine.SceneManagement;
//using UnityEngine.UIElements;

//public class GameManager : MonoBehaviour
//{
//    #region Variables

//    private bool paused; // Para saber si el juego está en pausa
//    public string menuSceneName = "Menu";
//    public GameObject pausePanel;
//    public GameObject panelVictoria;
//    public GameObject panelMuerte;

//    public float tiempoMinimo;  // Tiempo mínimo para obtener una estrella (en segundos)
//    [Header("Timer Settings")]
//    public float tiempoLimite;

//    [Header("UI References")]
//    public TextMeshProUGUI textoTimer;  // Referencia al TextMeshProUGUI para mostrar el tiempo

//    private float tiempoRestante;  // Tiempo restante en segundos
//    private bool timerActivo = true;  // Controla si el timer está activo o no
//    private bool isPaused = false;   // Controla si el timer está en pausa

//    #endregion Variables

//    void Start()
//    {
//        panelVictoria.SetActive(false);
//        pausePanel.SetActive(false);  // Inicialmente el panel de pausa está oculto
//        panelMuerte.SetActive(false);

//        // Inicializa el tiempo restante con el tiempo límite
//        tiempoRestante = tiempoLimite;

//        // Inicializamos el tiempo restante con el tiempo que empieza el nivel
//        tiempoRestante = tiempoMinimo;
//       // PauseGame();

//    }

//    void Update()
//    {

//        // Si el timer está activo y no está pausado
//        if (timerActivo && !isPaused)
//        {
//            // Decrementamos el tiempo usando unscaledDeltaTime para que no se vea afectado por la pausa
//            tiempoRestante -= Time.unscaledDeltaTime;

//            // Si el tiempo llega a 0, detenemos el timer
//            if (tiempoRestante <= 0f)
//            {
//                tiempoRestante = 0f;
//                timerActivo = false;
//                // Aquí podrías activar alguna lógica cuando el timer llegue a 0, como finalizar el nivel
//            }

//            // Actualizamos el texto del timer en el UI
//            ActualizarTextoTimer();
//        }
//    }
//    #region Funciones para el panel de pausa

//    // Activa el menú de pausa
//    //public void PauseGame()
//    //{
//    //    // Activar o desactivar el menú de pausa cuando el jugador presiona "P"
//    //    if (Input.GetKeyDown(KeyCode.P))
//    //    {
//    //        print("jalo");
//    //        if (paused)
//    //        {
//    //            ResumeGame();
//    //            ReanudarTimer();
//    //        }
//    //        else
//    //        {
//    //            PauseGame();
//    //            PausarTimer();
//    //        }
//    //    }
//    //    paused = true;
//    //    pausePanel.SetActive(true);  // Activar el panel de pausa
//    //    Time.timeScale = 0f;         // Detiene el tiempo del juego
//    //}

//    // Desactiva el menú de pausa
//    public void ResumeGame()
//    {
//        paused = false;
//        pausePanel.SetActive(false);  // Desactivar el panel de pausa
//        Time.timeScale = 1f;          // Reanuda el tiempo del juego
//    }

//    // Reinicia el nivel actual
//    public void RetryGame()
//    {
//        Time.timeScale = 1f;  // Asegura que el tiempo del juego esté en modo normal
//        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
//    }

//    // Carga la escena del menú principal
//    public void GoToMenu()
//    {
//        Time.timeScale = 1f;
//        SceneManager.LoadScene(menuSceneName);
//    }

//    // Salir del juego
//    public void GoToExit()
//    {
//        // Si estás en el editor de Unity, detiene el modo de juego
//        UnityEditor.EditorApplication.isPlaying = false;

//        Application.Quit();
//    }

//    #endregion Funciones para el panel de pausa

//    #region Funciones texto de tiempo 

//    void ActualizarTextoTimer()
//    {
//        float minutos = Mathf.FloorToInt(tiempoRestante / 60);
//        float segundos = Mathf.FloorToInt(tiempoRestante % 60);
//        textoTimer.text = string.Format("{0:00}:{1:00}", minutos, segundos);
//    }
//    public void DetenerTimer()
//    {
//        timerActivo = false;
//    }
//    public void PausarTimer()
//    {
//        isPaused = true;
//        Time.timeScale = 0f;  // Detiene el tiempo del juego (efecto global de pausa)
//    }
//    public void ReanudarTimer()
//    {
//        isPaused = false;
//        Time.timeScale = 1f;  // Restaura el tiempo del juego (efecto global de reanudación)
//    }

//    #endregion Funciones texto de tiempo
//}
