using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjetivoController : MonoBehaviour
{
    public GameObject objetoAEliminar; // Asigna en el Inspector el objeto que debe ser destruido

    void Update()
    {
        if (objetoAEliminar == null) // Si el objeto fue destruido
        {
            Debug.Log("¡Objetivo completado! Regresando a la escena anterior...");
            RegresarEscenaAnterior();
        }
    }

    void RegresarEscenaAnterior()
    {
        int escenaActual = SceneManager.GetActiveScene().buildIndex;

        if (escenaActual > 0)
        {
            SceneManager.LoadScene(escenaActual - 1);
        }
        else
        {
            Debug.Log("No hay escena anterior.");
        }
    }
}
