using UnityEngine;

public class PosicionarJugador : MonoBehaviour
{
    void Start()
    {
        // Si hay una posici�n guardada, mueve al jugador a esa ubicaci�n
        if (PlayerPrefs.HasKey("PosX"))
        {
            float x = PlayerPrefs.GetFloat("PosX");
            float y = PlayerPrefs.GetFloat("PosY");
            float z = PlayerPrefs.GetFloat("PosZ");
            transform.position = new Vector3(x, y, z);
        }
    }
}

