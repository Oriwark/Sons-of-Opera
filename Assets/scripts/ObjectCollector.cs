using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiarEscenaPorCantidad : MonoBehaviour
{
    public int cantidadObjetosNecesarios = 1; // Cambia esto según tu necesidad
    private int objetosRecogidos = 0;
    public string nombreDeLaSiguienteEscena = "SampleScene";

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Nota"))
        {
            objetosRecogidos++;
            Destroy(other.gameObject);

            Debug.Log("Objetos recogidos: " + objetosRecogidos);

            if (objetosRecogidos >= cantidadObjetosNecesarios)
            {
                SceneManager.LoadScene(nombreDeLaSiguienteEscena);
            }
        }
    }
}
