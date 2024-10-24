using CustomEventBus;
using UnityEngine;
using Zenject;

namespace Gameplay.Items
{
    public class Item : MonoBehaviour, IClickInteractable
    {
        private EventBus _eventBus;
        [field: SerializeField] public ItemData ItemData { get; private set; }

        [Inject]
        public void Construct(EventBus eventBus)
        {
            _eventBus = eventBus;
        }
        
        public void Initialize(ItemData itemData)
        {
            ItemData = itemData;
        }

        public void Interact()
        {
            _eventBus.Invoke(new ItemClickedSignal(this));
        }
    }
}