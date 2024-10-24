using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] private float sensitivity = 2.0f; 
    [SerializeField] private float maxYAngle = 80.0f; 
    
    private float rotationX = 0.0f;
    private InputService _inputService;

    [Inject]
    public void Construct(InputService inputService)
    {
        _inputService = inputService;
    }
    
    private void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");


        transform.parent.Rotate(Vector3.up * mouseX * sensitivity);
        

        rotationX -= mouseY * sensitivity;
        rotationX = Mathf.Clamp(rotationX, -maxYAngle, maxYAngle);
        transform.localRotation = Quaternion.Euler(rotationX, 0.0f, 0.0f);
    }
}
