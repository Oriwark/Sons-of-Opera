using UnityEngine;

public class PlayerInteractor : MonoBehaviour
{
    public float distanciaInteraccion = 3f;
    public LayerMask capaInteractuable;

    private Camera camara;

    void Start()
    {
        camara = Camera.main;
    }

    void Update()
    {
        Interactuar();
    }

    void Interactuar()
    {
        // Lanza un rayo desde el centro de la cámara
        Ray rayo = new Ray(camara.transform.position, camara.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(rayo, out hit, distanciaInteraccion, capaInteractuable))
        {
            // Verifica si el objeto tiene el componente "Interactable"
            Interactable interactuable = hit.collider.GetComponent<Interactable>();
            if (interactuable != null)
            {
                Debug.Log("Presiona 'E' para interactuar con " + hit.collider.gameObject.name);

                if (Input.GetKeyDown(KeyCode.E))
                {
                    interactuable.AccionInteractuar();
                }
            }
        }
    }
}
