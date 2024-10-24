using System;
using System.Collections;
using System.Collections.Generic;
using Gameplay.Items;
using UnityEngine;

public class ItemsGroup : MonoBehaviour
{
    [SerializeField] private ItemPlace[] itemPlaces;
    
    public void InitializeGroup(List<Item> items)
    {
        if (itemPlaces.Length < items.Count)
            throw new ArgumentException("Not enough places to create all items!");

        for (int i = 0; i < items.Count; i++)
        {
            var item = items[i];
            itemPlaces[i].Put(item);
        }
    }
}
