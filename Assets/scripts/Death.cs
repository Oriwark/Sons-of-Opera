using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverTrigger3D : MonoBehaviour
{
    [SerializeField] private string sceneToLoad = "GameOver"; // Cambia esto si tu escena tiene otro nombre

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Algo tocó el trigger: " + other.name);

        if (other.CompareTag("Player"))
        {
            Debug.Log("¡Jugador detectado! Cargando escena de muerte...");
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}

