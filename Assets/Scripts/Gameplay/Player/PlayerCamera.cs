using System;
using System.Collections;
using System.Collections.Generic;
using Infrastructure.Services;
using UnityEngine;
using Zenject;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] private float sensitivity = 2.0f; 
    [SerializeField] private float maxYAngle = 80.0f; 
    
    private float _rotationX = 0.0f;
    private StandaloneInputService _inputService;

    [Inject]
    public void Construct(StandaloneInputService inputService)
    {
        this._inputService = inputService;
    }

    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        var mouseDirection = _inputService.GetMouseDirection();
        
        float mouseX = mouseDirection.x;
        float mouseY = mouseDirection.y;


        transform.parent.Rotate(Vector3.up * mouseX * sensitivity);
        

        _rotationX -= mouseY * sensitivity;
        _rotationX = Mathf.Clamp(_rotationX, -maxYAngle, maxYAngle);
        transform.localRotation = Quaternion.Euler(_rotationX, 0.0f, 0.0f);
    }
}
