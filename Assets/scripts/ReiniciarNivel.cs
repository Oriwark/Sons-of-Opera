using UnityEngine;
using UnityEngine.SceneManagement; // Importa la librería para reiniciar escenas

public class ReiniciarNivel : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) // Para juegos 2D
    {
        if (other.CompareTag("Player")) // Verifica si el objeto tiene la etiqueta "Jugador"
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reinicia el nivel
        }
    }

    private void OnTriggerEnter(Collider other) // Para juegos 3D
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}

