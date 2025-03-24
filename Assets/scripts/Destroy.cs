using UnityEngine;
using UnityEngine.SceneManagement; // Necesario para reiniciar el nivel

public class DestruirYReiniciar : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) // Para 2D
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject); // Destruye este objeto
            SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reinicia el nivel
        }
    }

    private void OnTriggerEnter(Collider other) // Para 3D
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
