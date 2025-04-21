using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    // Reinicia la escena actual
    public void RetryLevel()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }

    // Cierra el juego (funciona solo en compilado, no en el editor)
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Juego cerrado"); // Para ver en el editor
    }
}
