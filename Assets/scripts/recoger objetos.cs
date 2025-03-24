using UnityEngine;

public class ContadorObjetos : MonoBehaviour
{
    public int objetosNecesarios = 10; // Número de objetos a recoger
    private int contador = 0; // Contador de objetos recogidos
    public GameObject objetoADestruir; // Objeto que se destruirá al alcanzar el número

    public void RecogerObjeto()
    {
        contador++; // Aumenta el contador al recoger un objeto

        if (contador >= objetosNecesarios) // Si alcanza el límite
        {
            Destroy(objetoADestruir); // Destruye el objeto especificado
        }
    }
}
