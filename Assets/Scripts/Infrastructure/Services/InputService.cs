using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputService
{
    private Vector3 MoveDir;
    
    public Vector3 GetMoveDirection()
    {
        return new Vector3(Input.GetAxis("Horizontal"), 0 ,Input.GetAxis("Vertical"));
    }
    public Vector3 GetMouseDirection()
    {
        return new Vector3(Input.GetAxis("Mouse X"), 0 ,Input.GetAxis("Vertical"));
    }
}
