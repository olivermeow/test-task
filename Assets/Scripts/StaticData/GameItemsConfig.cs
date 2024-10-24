using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.Items
{
    [CreateAssetMenu(menuName = "Item/New Items Config", fileName = "New Items Config")]
    public class GameItemsConfig : ScriptableObject
    {
        [SerializeField] private List<ItemData> items;

        public IEnumerable<ItemData> Items => items;
    }
}