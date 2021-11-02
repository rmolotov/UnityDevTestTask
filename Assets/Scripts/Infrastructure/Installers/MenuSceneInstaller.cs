using System.Collections;
using System.Collections.Generic;
using Menu.Models;
using Menu.ViewModels;
using UnityEngine;
using Zenject;

namespace Infrastructure.Installers
{
    public class MenuSceneInstaller: MonoInstaller
    {
        [SerializeField] private CardsDeckVm cardsDeck;
        [SerializeField] private GameObject cardPrefab;
        [SerializeField] private List<CardModel> testCards;

        public override void InstallBindings()
        {
            MenuSceneController menuSceneController = new MenuSceneController(Random.Range(20, 200));

            Container
                .Bind<MenuSceneController>()
                .FromInstance(menuSceneController)
                .AsSingle();

            Container.Bind<CardsDeckVm>()
                .FromInstance(cardsDeck)
                .AsSingle();

            foreach (var testCard in testCards)
            {
                CardVm card = Container
                    .InstantiatePrefabForComponent<CardVm>(
                        cardPrefab,
                        cardsDeck.transform
                    );
                card.Construct(testCard, menuSceneController);
            }
        }
    }
}