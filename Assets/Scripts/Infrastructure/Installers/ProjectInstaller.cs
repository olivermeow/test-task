using System.Collections;
using System.Collections.Generic;
using CustomEventBus;
using Gameplay.Items;
using UnityEngine;
using Zenject;

public class ProjectInstaller : MonoInstaller
{
    [SerializeField] private GameItemsConfig gameItemsConfig;

    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<InputService>().AsSingle().NonLazy();
        Container.BindInterfacesAndSelfTo<GameFactory>().AsSingle().NonLazy();
        
        
        Container.Bind<GameItemsConfig>().FromInstance(gameItemsConfig).AsSingle().NonLazy();

        Container.Bind<EventBus>().AsSingle().NonLazy();
    }
}
