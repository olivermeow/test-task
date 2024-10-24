using System;
using System.Collections;
using UnityEngine;

namespace Gameplay.Items
{
    public class ItemPlace : MonoBehaviour
    {
        public Item Item { get; private set; }
        public bool Occupied { get; private set; }

        public void Put(Item item)
        {
            Item = item;
            Occupied = true;
            
            item.transform.position = transform.position;
            
        }
        public void Take()
        {
            Item = null;
            Occupied = false;
        }
    }
}
