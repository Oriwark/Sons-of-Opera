using UnityEngine;

public class PosicionarJugador : MonoBehaviour
{
    void Start()
    {
        // Si hay una posición guardada, mueve al jugador a esa ubicación
        if (PlayerPrefs.HasKey("PosX"))
        {
            float x = PlayerPrefs.GetFloat("PosX");
            float y = PlayerPrefs.GetFloat("PosY");
            float z = PlayerPrefs.GetFloat("PosZ");
            transform.position = new Vector3(x, y, z);
        }
    }
}

