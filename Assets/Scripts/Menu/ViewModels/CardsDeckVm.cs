using System;
using System.Collections.Generic;
using DG.Tweening;
using Infrastructure.Installers;
using Menu.Models;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Menu.ViewModels
{
    public class CardsDeckVm: MonoBehaviour
    {
        [SerializeField] private Image leftScrollArrow, rightScrollArrow;
        [SerializeField] private Scrollbar deckScrollBar;
        private List<Image> _leftScrollImages = new List<Image>(), _rightScrollImages = new List<Image>();

        [Inject]
        private void Construct(MenuSceneController menuSceneController)
        {
            _leftScrollImages.Add(leftScrollArrow);
            _leftScrollImages.AddRange(leftScrollArrow.GetComponentsInChildren<Image>());
            
            _rightScrollImages.Add(rightScrollArrow);
            _rightScrollImages.AddRange(rightScrollArrow.GetComponentsInChildren<Image>());
            
            deckScrollBar.onValueChanged.AddListener(HandleScrollArrows);
        }

        private void HandleScrollArrows(float sliderValue)
        {
            foreach (var image in _leftScrollImages)
            {
                image
                    .DOFade(sliderValue, 0.1f)
                    .From();
            }
            foreach (var image in _rightScrollImages)
            {
                image
                    .DOFade(1-sliderValue, 0.1f)
                    .From();
            }
        }
    }
}