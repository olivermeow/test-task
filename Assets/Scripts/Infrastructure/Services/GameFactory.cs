using UnityEngine;
using Zenject;

namespace Gameplay.Items
{
    public class GameFactory
    {
        private DiContainer _container;

        public GameFactory(DiContainer container)
        {
            _container = container;
            Debug.Log(_container == null);
        }
        public Item CreateItem(ItemData itemData)
        {
            var itemGameObject = GameObject.Instantiate(itemData.Prefab);
            var itemComponent = itemGameObject.GetComponent<Item>();
            itemComponent.Initialize(itemData);
            _container.InjectGameObject(itemGameObject);
            return itemComponent;
        }
    }
}