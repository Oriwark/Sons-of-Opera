using UnityEngine;


public class MovimientoCiclico : MonoBehaviour
{
    public Vector3 puntoInicial;
    public Vector3 puntoFinal;
    public float velocidad = 5f;
    public float tiempoEspera = 0.5f;

    private bool enMovimiento = true;

    void Start()
    {
        transform.position = puntoInicial;
        StartCoroutine(MoverCiclicamente());
    }

    System.Collections.IEnumerator MoverCiclicamente()
    {
        while (true)
        {
            // Mover hacia el punto final
            while (Vector3.Distance(transform.position, puntoFinal) > 0.1f)
            {
                transform.position = Vector3.MoveTowards(transform.position, puntoFinal, velocidad * Time.deltaTime);
                yield return null;
            }

            // Desaparece
            gameObject.SetActive(false);
            yield return new WaitForSeconds(tiempoEspera);

            // Volver al punto inicial y reaparecer
            transform.position = puntoInicial;
            gameObject.SetActive(true);
            yield return new WaitForSeconds(tiempoEspera);
        }
    }
}

