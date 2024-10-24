using CustomEventBus;
using Gameplay.Items;
using Infrastructure.Services;
using UnityEngine;
using Zenject;

namespace Infrastructure.Installers
{
    public class ProjectInstaller : MonoInstaller
    {
        [SerializeField] private GameItemsConfig gameItemsConfig;

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<StandaloneInputService>().AsSingle().NonLazy();
        
            Container.BindInterfacesAndSelfTo<GameFactory>().AsSingle().NonLazy();
        
        
            Container.Bind<GameItemsConfig>().FromInstance(gameItemsConfig).AsSingle().NonLazy();

            Container.Bind<EventBus>().AsSingle().NonLazy();
        }
    }
}
