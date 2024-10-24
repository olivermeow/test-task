using UnityEngine;

namespace Gameplay.Items
{
    [CreateAssetMenu(menuName = "Item/New Item", fileName = "New Item")]
    public class ItemData : ScriptableObject
    {
        [field: SerializeField] public ItemType ItemType { get; private set; }
        [field: SerializeField] public GameObject Prefab { get; private set; }
    }
}