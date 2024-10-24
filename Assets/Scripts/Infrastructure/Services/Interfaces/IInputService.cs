using UnityEngine;

public interface IInputService
{
    public bool GetLeftClick();
    public Vector2 GetMouseDirection();
    public Vector2 GetMoveDirection();
}