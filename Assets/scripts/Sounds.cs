using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    public AudioClip sonidoRecolectar; // Sonido a reproducir
    private AudioSource audioSource; // Componente de audio

    private void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>(); // Añade un AudioSource al objeto
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Si el jugador lo toca
        {
            audioSource.PlayOneShot(sonidoRecolectar); // Reproduce el sonido
            Destroy(gameObject, sonidoRecolectar.length); // Destruye el objeto después del sonido
        }
    }
}
