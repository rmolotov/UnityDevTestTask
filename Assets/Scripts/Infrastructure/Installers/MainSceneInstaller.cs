using System;
using UnityEngine;
using Zenject;

namespace Infrastructure.Installers
{
    public class MainSceneInstaller : MonoInstaller
    {
        [SerializeField] private GameObject animGameObject;
        public override void InstallBindings()
        {
            Container
                .BindInterfacesTo<MainScene>()
                .AsSingle()
                .WithArguments(animGameObject)
                .NonLazy();
        }
    }
}