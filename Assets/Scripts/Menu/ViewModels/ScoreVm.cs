using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Infrastructure.Installers;
using Zenject;

namespace Menu.ViewModels
{
    public class ScoreVm: MonoBehaviour
    {
        private List<TextMeshProUGUI> _textParts = new List<TextMeshProUGUI>();

        [SerializeField] [Range(0.1f, 10f)] private float animDuration;
        [SerializeField] private Image _starImage;
        [SerializeField] private TextMeshProUGUI _userScoreText;
         

        private int _userScore;
        public int UserScore
        {
            get => _userScore;
            set
            {
                _starImage.transform
                    .DOLocalRotate(Vector3.forward * 360, animDuration, RotateMode.FastBeyond360)
                    .SetEase(Ease.OutQuad);
                _userScoreText.transform
                    .DOScale(1f, animDuration)
                    .SetEase(Ease.OutBack);
                
                foreach (var textPart in _textParts)
                {
                    textPart
                        .DOCounter(_userScore, value, animDuration)
                        .SetEase(Ease.OutQuad);
                }
                _userScore = value;
            }
        }

        [Inject]
        private void Construct(MenuSceneController menuSceneController)
        {
            _textParts.Add(_userScoreText);
            _textParts.AddRange(_userScoreText.GetComponentsInChildren<TextMeshProUGUI>());
            UserScore = menuSceneController.UserScore;
        }
    }
}