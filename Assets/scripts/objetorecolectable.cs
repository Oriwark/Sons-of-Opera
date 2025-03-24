using UnityEngine;

public class ObjetoRecolectable : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) // Para 2D
    {
        if (other.CompareTag("Player"))
        {
            FindObjectOfType<ContadorObjetos>().RecogerObjeto(); // Llama a la función del contador
            Destroy(gameObject); // Destruye el objeto recolectado
        }
    }

    private void OnTriggerEnter(Collider other) // Para 3D
    {
        if (other.CompareTag("Player"))
        {
            FindObjectOfType<ContadorObjetos>().RecogerObjeto();
            Destroy(gameObject);
        }
    }
}
