using UnityEngine;
using UnityEngine.SceneManagement; // Necesario para cambiar de escena

public class CambiarEscena : MonoBehaviour
{
    public string nombreEscena; // Nombre de la escena a cargar

    private void OnTriggerEnter2D(Collider2D other) // Para 2D
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(nombreEscena); // Cambia a la escena especificada
        }
    }

    private void OnTriggerEnter(Collider other) // Para 3D
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(nombreEscena);
        }
    }
}
