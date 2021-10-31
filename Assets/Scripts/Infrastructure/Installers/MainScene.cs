using Infrastructure.Signals;
using UnityEngine;
using Zenject;

namespace Infrastructure.Installers
{
    public class MainScene : IInitializable
    {
        private readonly SignalBus _signalBus;
        private readonly GameObject _prefab;
        public MainScene(GameObject prefab, SignalBus signalBus)
        {
            _prefab = prefab;
            _signalBus = signalBus;
        }

        public void Initialize()
        {
            _signalBus.Fire(new OnSceneLoadedSignal{ CharController = _prefab });
        }
    }
}