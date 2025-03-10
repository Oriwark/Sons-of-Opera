using UnityEngine;

public class BotonAbrirPuerta : Interactable
{
    public GameObject puerta;
    public float alturaApertura = 3f;
    public float velocidad = 2f;
    private bool abierta = false;

    public override void AccionInteractuar()
    {
        if (!abierta)
        {
            Debug.Log("¡Puerta Abierta!");
            abierta = true;
            StartCoroutine(AbrirPuerta());
        }
    }

    private System.Collections.IEnumerator AbrirPuerta()
    {
        Vector3 nuevaPosicion = puerta.transform.position + Vector3.up * alturaApertura;
        while (Vector3.Distance(puerta.transform.position, nuevaPosicion) > 0.01f)
        {
            puerta.transform.position = Vector3.Lerp(puerta.transform.position, nuevaPosicion, velocidad * Time.deltaTime);
            yield return null;
        }
    }
}

