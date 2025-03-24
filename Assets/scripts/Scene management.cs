using UnityEngine;
using UnityEngine.SceneManagement; // Necesario para gestionar escenas

public class VolverAEscenaAnterior : MonoBehaviour
{
    public void RegresarEscenaAnterior()
    {
        int escenaActual = SceneManager.GetActiveScene().buildIndex; // Obtiene el índice de la escena actual

        if (escenaActual > 0) // Asegura que no estás en la primera escena
        {
            SceneManager.LoadScene("MenuPrincipal"); // Cambia "MenuPrincipal" por el nombre de tu escena

        }
    }
}
