using UnityEngine;
using System.Collections;

public class MovimientoCoche : MonoBehaviour
{
    public Vector3 puntoInicial;
    public Vector3 puntoFinal;
    public float velocidad = 5f;
    public float tiempoEspera = 0.5f;

    public Transform[] ruedas;
    public float velocidadRotacion = 360f;

    public Renderer[] renderers; // Asigna todos los renderers del coche

    void Start()
    {
        transform.position = puntoInicial;
        StartCoroutine(MoverYReiniciar());
    }

    IEnumerator MoverYReiniciar()
    {
        while (true)
        {
            // Mover hacia punto final
            while (Vector3.Distance(transform.position, puntoFinal) > 0.1f)
            {
                transform.position = Vector3.MoveTowards(transform.position, puntoFinal, velocidad * Time.deltaTime);

                foreach (Transform rueda in ruedas)
                {
                    rueda.Rotate(Vector3.right, velocidadRotacion * Time.deltaTime, Space.Self);
                }

                yield return null;
            }

            yield return new WaitForSeconds(tiempoEspera);

            // ✨ Desvanecer (Fade Out)
            yield return StartCoroutine(FadeOut());

            // Teletransportar
            transform.position = puntoInicial;

            // ✨ Reaparecer (Fade In)
            yield return StartCoroutine(FadeIn());

            yield return new WaitForSeconds(tiempoEspera);
        }
    }

    IEnumerator FadeOut(float duration = 1f)
    {
        float elapsed = 0f;
        while (elapsed < duration)
        {
            float alpha = Mathf.Lerp(1f, 0f, elapsed / duration);
            SetAlpha(alpha);
            elapsed += Time.deltaTime;
            yield return null;
        }
        SetAlpha(0f);
    }

    IEnumerator FadeIn(float duration = 1f)
    {
        float elapsed = 0f;
        while (elapsed < duration)
        {
            float alpha = Mathf.Lerp(0f, 1f, elapsed / duration);
            SetAlpha(alpha);
            elapsed += Time.deltaTime;
            yield return null;
        }
        SetAlpha(1f);
    }

    void SetAlpha(float alpha)
    {
        foreach (Renderer r in renderers)
        {
            foreach (Material mat in r.materials)
            {
                Color c = mat.color;
                c.a = alpha;
                mat.color = c;
            }
        }
    }
}

