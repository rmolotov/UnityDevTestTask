using Infrastructure.Signals;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.SceneManagement;
using Zenject;

namespace Infrastructure
{
    public class ARModule : IInitializable
    {
        private readonly ARTrackedImageManager _trackedImageManager;
        private readonly SignalBus _signalBus;
        private readonly int _mainSceneIndex;

        public ARModule(ARTrackedImageManager trackedImageManager, int mainScene, SignalBus signalBus)
        {
            _trackedImageManager = trackedImageManager;
            _signalBus = signalBus;
            _mainSceneIndex = mainScene;
        }

        public void Initialize()
        {
            _signalBus.Subscribe<OnSceneLoadedSignal>(SetTrackedImagePrefab);
            SceneManager.LoadSceneAsync(_mainSceneIndex, LoadSceneMode.Additive);
        }

        private void SetTrackedImagePrefab(OnSceneLoadedSignal arg)
        {
            _trackedImageManager.trackedImagePrefab = arg.CharController.gameObject;
        }
    }
}