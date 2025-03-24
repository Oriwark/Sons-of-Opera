using UnityEngine;
using UnityEngine.SceneManagement; // Necesario para gestionar escenas

public class VolverAEscenaAnterior : MonoBehaviour
{
    public void RegresarEscenaAnterior()
    {
        int escenaActual = SceneManager.GetActiveScene().buildIndex; // Obtiene el �ndice de la escena actual

        if (escenaActual > 0) // Asegura que no est�s en la primera escena
        {
            SceneManager.LoadScene("MenuPrincipal"); // Cambia "MenuPrincipal" por el nombre de tu escena

        }
    }
}
