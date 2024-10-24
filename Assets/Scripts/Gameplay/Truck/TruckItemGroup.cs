using System.Collections.Generic;
using System.Linq;
using Gameplay.Items;
using Gameplay.Player;
using UnityEngine;

namespace Gameplay.Truck
{
    public class TruckItemGroup : MonoBehaviour, IClickInteractable
    {
        [SerializeField] private PlayerHands playerHands;

        [SerializeField] private List<ItemPlace> itemPlaces;
        public void Interact()
        {
            if (playerHands.TryTake(out Item item))
            {
                var freePlace = itemPlaces.FirstOrDefault(place => place.Occupied == false);
            
                if (freePlace == null)
                    return;

                var itemTransform = item.transform;
                var freePlaceTransform = freePlace.transform;
                itemTransform.parent = freePlaceTransform.parent;
                itemTransform.rotation = freePlaceTransform.rotation;
                freePlace.Put(item);
            }
        }
    }
}
