using UnityEngine;

namespace Infrastructure.Services
{
    public class StandaloneInputService : IInputService
    {
        public Vector2 GetMoveDirection()
        {
            return new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        }
        public Vector2 GetMouseDirection()
        {
            return new Vector3(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        }

        public bool GetLeftClick()
        {
            return Input.GetMouseButtonDown(0);
        }
    }
}