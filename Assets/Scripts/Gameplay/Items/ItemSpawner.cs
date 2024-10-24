using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Gameplay.Items
{
    public class ItemSpawner : MonoBehaviour
    {
        [SerializeField] private ItemsGroup _itemsGroup;
        
        private GameItemsConfig _gameItemsConfig;
        private GameFactory _gameFactory;
        

        [Inject]
        public void Construct(GameItemsConfig gameItemsConfig, GameFactory gameFactory)
        {
            _gameItemsConfig = gameItemsConfig;
            _gameFactory = gameFactory;
        }
        public void Start()
        {
            InitializeItems();
        }

        public void InitializeItems()
        {
            List<Item> items = new List<Item>();
            
            foreach (var itemData in _gameItemsConfig.Items)
            {
                var item = _gameFactory.CreateItem(itemData);
                items.Add(item);
            }
            
            _itemsGroup.InitializeGroup(items);
        }
    }
}