using System.Collections;
using System.Collections.Generic;
using Gameplay.Items;
using UnityEngine;

public class ItemClickedSignal
{
    public readonly Item Item;

    public ItemClickedSignal(Item item)
    {
        Item = item;
    }
}
