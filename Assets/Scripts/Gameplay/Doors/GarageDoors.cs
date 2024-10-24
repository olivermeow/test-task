using System;
using System.Collections;
using System.Collections.Generic;
using Gameplay.Doors;
using Gameplay.Player;
using UnityEngine;

public class GarageDoors : MonoBehaviour, IClickInteractable
{
    [SerializeField] private PlayerRaycast _playerRaycast;
    [SerializeField] private Door[] _doors;

    private bool Openned;

    public void Interact()
    {
        
        foreach (var door in _doors)
        {
            door.Open();
            Openned = true;
        }
    }
    
    
}