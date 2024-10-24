using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Gameplay.Items;
using UnityEngine;

public class TruckItemGroup : MonoBehaviour, IClickInteractable
{
    [SerializeField] private PlayerHands _playerHands;

    [SerializeField] private List<ItemPlace> _itemPlaces;
    public void Interact()
    {
        if (_playerHands.TryTake(out Item item))
        {
            var freePlace = _itemPlaces.FirstOrDefault(place => place.Occupied == false);
            
            if (freePlace == null)
                return;

            item.transform.parent = freePlace.transform.parent;
            item.transform.rotation = freePlace.transform.rotation;
            freePlace.Put(item);
        }
    }
}
