using UnityEngine;

public class MovimientoCoche : MonoBehaviour
{
    public Vector3 puntoInicial;
    public Vector3 puntoFinal;
    public float velocidad = 5f;
    public float tiempoEspera = 0.5f;

    // Ruedas
    public Transform[] ruedas; // Asigna 4 ruedas en el inspector
    public float velocidadRotacion = 360f; // grados por segundo

    private bool yendoAlFinal = true;

    void Start()
    {
        transform.position = puntoInicial;
        StartCoroutine(MoverCiclicamente());
    }

    System.Collections.IEnumerator MoverCiclicamente()
    {
        while (true)
        {
            Vector3 destino = yendoAlFinal ? puntoFinal : puntoInicial;

            while (Vector3.Distance(transform.position, destino) > 0.1f)
            {
                // Mover el coche
                transform.position = Vector3.MoveTowards(transform.position, destino, velocidad * Time.deltaTime);

                // Rotar las ruedas
                foreach (Transform rueda in ruedas)
                {

                    // Algunas variantes que podrías probar:
                    rueda.Rotate(Vector3.forward, velocidadRotacion * Time.deltaTime, Space.Self);


                    yield return null;
                }

                // Pequeña pausa y luego invertir dirección
                yield return new WaitForSeconds(tiempoEspera);
                yendoAlFinal = !yendoAlFinal;
            }
        }
    }
}
