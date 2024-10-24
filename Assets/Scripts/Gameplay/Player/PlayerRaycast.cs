using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Gameplay.Player
{
    public class PlayerRaycast : MonoBehaviour
    {
        [SerializeField] private LayerMask InteractLayerMask;
        
        private Camera mainCamera;

        private void Start()
        {
            mainCamera = Camera.main;
        }
        private void Update()
        {
            Vector3 rayStartPosition = new Vector3(Screen.width/2, Screen.height/2, 0);
        
            Ray ray = mainCamera.ScreenPointToRay(rayStartPosition);
        
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (Input.GetMouseButtonDown(0))
                {
                    if (hit.collider.TryGetComponent<IClickInteractable>( out var clickInteractable))
                        clickInteractable.Interact();
                }
            }
        }
    }
}
