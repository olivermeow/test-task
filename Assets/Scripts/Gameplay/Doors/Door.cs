using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace Gameplay.Doors
{
    public class Door : MonoBehaviour
    {
        [SerializeField] private DoorDirectionType directionType;
        
        private Dictionary<DoorDirectionType, Vector3> OpenVectorMap = new Dictionary<DoorDirectionType, Vector3>()
        {
            {DoorDirectionType.Left, new Vector3(0, -90f, 0)},
            {DoorDirectionType.Right, new Vector3(0, 90f, 0)},
            {DoorDirectionType.Down, new Vector3(-90f, 0, 0)},
            {DoorDirectionType.Up, new Vector3(90f, 0, 0)}
            
        };
        

        public void Open()
        {
            transform.DORotate(GetVectorByType(), 0.5f).SetEase(Ease.Linear);
        }

        public void Close()
        {
            transform.DORotate(new Vector3(-90f, 0, 0), 0.5f).SetEase(Ease.Linear); 
        }

        private Vector3 GetVectorByType()
        {
            if (OpenVectorMap.TryGetValue(directionType, out var vector))
                return vector;
            
            throw new ArgumentException($"No {directionType} in dictionary!");
        }
    }

    public enum DoorDirectionType
    {
        Left,
        Right,
        Up,
        Down
    }
}
