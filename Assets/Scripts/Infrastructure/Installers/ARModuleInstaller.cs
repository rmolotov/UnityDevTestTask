using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.ARFoundation;
using Zenject;

namespace Infrastructure.Installers
{
    public class ARModuleInstaller : MonoInstaller
    {
        [SerializeField] private ARTrackedImageManager _trackedImageManager;
        [SerializeField] private int mainSceneIndex;
        
        public override void InstallBindings()
        {
            Container
                .BindInterfacesTo<ARModule>()
                .AsSingle()
                .WithArguments(_trackedImageManager, mainSceneIndex)
                .NonLazy();
        }
    }
}