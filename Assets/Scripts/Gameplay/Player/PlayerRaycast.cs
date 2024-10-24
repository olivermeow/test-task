using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Gameplay.Player
{
    public class PlayerRaycast : MonoBehaviour
    {
        private Dictionary<string, Action> InputActionMap = new Dictionary<string, Action>();
        private string[] actionTags;

        private Camera mainCamera;

        private void Start()
        {
            mainCamera = Camera.main;
            InitializeActionMap();
        }

        private void InitializeActionMap()
        {
            InputActionMap.Add("Garbage", GarageClicked);

            actionTags = InputActionMap.Select(kvp => kvp.Key).ToArray();
        }
        
        public event Action GarageClicked;
        private void Update()
        {
            Vector3 rayStartPosition = new Vector3(Screen.width/2, Screen.height/2, 0);
        
            Ray ray = mainCamera.ScreenPointToRay(rayStartPosition);
        
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                foreach (var tag in actionTags)
                {
                    if (hit.collider.CompareTag(tag))
                    {
                        InputActionMap[tag]?.Invoke();
                    } 
                }
            }
        }
    }
}
