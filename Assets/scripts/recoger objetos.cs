using UnityEngine;

public class ContadorObjetos : MonoBehaviour
{
    public int objetosNecesarios = 10; // N�mero de objetos a recoger
    private int contador = 0; // Contador de objetos recogidos
    public GameObject objetoADestruir; // Objeto que se destruir� al alcanzar el n�mero

    public void RecogerObjeto()
    {
        contador++; // Aumenta el contador al recoger un objeto

        if (contador >= objetosNecesarios) // Si alcanza el l�mite
        {
            Destroy(objetoADestruir); // Destruye el objeto especificado
        }
    }
}
