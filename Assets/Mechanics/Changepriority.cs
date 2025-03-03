using UnityEngine;
using Unity.Cinemachine;

public class Changepriority : MonoBehaviour
{
    [SerializeField] protected CinemachineCamera CinemachineCamera;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CinemachineCamera = GetComponent<CinemachineCamera>();
    }

    // Update is called once per frame
    public void ChangePriority (int value)
    {
        CinemachineCamera.Priority = value;
    }
    
        
    
}
