using CustomEventBus;
using Gameplay.Items;
using UnityEngine;
using Zenject;

namespace Gameplay.Player
{
    public class PlayerHands : MonoBehaviour
    {
        [SerializeField] private Transform handPoint;
        private Item _currentItem;
        private EventBus _eventBus;

        public bool IsBusy { get; private set; }
    
        [Inject]
        public void Construct(EventBus eventBus)
        {
            _eventBus = eventBus;
        }

        private void Awake()
        {
            _eventBus.Subscribe<ItemClickedSignal>(OnItemClicked);
        }

        private void OnDisable()
        {

            _eventBus.Unsubscribe<ItemClickedSignal>(OnItemClicked);
        
        }

        private void OnItemClicked(ItemClickedSignal obj)
        {
            if (IsBusy)
            {
                return;
            }
            Take(obj.Item);
        }

        public void Take(Item item)
        {
            if (IsBusy)
                return;
        
            IsBusy = true;
            _currentItem = item;
            var itemTransform = _currentItem.transform;
            itemTransform.parent = handPoint;
            itemTransform.position = handPoint.position;
        }

        public bool TryTake(out Item item)
        {
            if (!IsBusy)
            {
                item = null;
                return false;
            }
            IsBusy = false;
            item = _currentItem;
            return true;
        }
    }
}
