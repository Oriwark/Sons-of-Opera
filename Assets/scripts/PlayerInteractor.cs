using UnityEngine;

public class Interactable : MonoBehaviour
{
    public virtual void AccionInteractuar()
    {
        Debug.Log("Interacción realizada con " + gameObject.name);
    }
}