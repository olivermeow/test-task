using System;
using System.Collections;
using System.Collections.Generic;
using CustomEventBus;
using DG.Tweening;
using Gameplay.Items;
using UnityEngine;
using Zenject;

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
        IsBusy = true;
        _currentItem = item;
        _currentItem.transform.rotation = handPoint.rotation;
        item.transform
            .DOMove(handPoint.position, 0.3f).SetEase(Ease.Linear)
            .OnComplete((() =>
            {
                var itemTransform = item.transform;
                itemTransform.parent = handPoint;
            }));
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
