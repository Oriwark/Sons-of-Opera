using UnityEngine;

public class Interactable : MonoBehaviour
{
    public virtual void AccionInteractuar()
    {
        Debug.Log("Interacci�n realizada con " + gameObject.name);
    }
}