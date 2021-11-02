using Infrastructure.Installers;
using Menu.Models;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Menu.ViewModels
{
    public class CardVm: MonoBehaviour
    {
        [SerializeField] private Image _cardContentImage;
        [SerializeField] private TextMeshProUGUI _cardNameText;
        [SerializeField] private TextMeshProUGUI _userScoreText;
        [SerializeField] private TextMeshProUGUI _maxScoreText;
        [SerializeField] private Button _button;

        private int _userScore;
        public int UserScore
        {
            get => _userScore;
            set {
                _userScore = value;
                _userScoreText.text = _userScore.ToString();
            }
        }

        private int _maxScore;
        public int MaxScore {
            get => _maxScore;
            set {
                _maxScore = value;
                _maxScoreText.text = _maxScore.ToString();
            }
            
        }
        
        public void Construct(CardModel cardModel, MenuSceneController menuSceneController)
        {
            UserScore = cardModel.UserScore;
            MaxScore = cardModel.MaxScore;
            _cardNameText.text = cardModel.CardName;
            foreach (var textPart in _cardNameText.GetComponentsInChildren<TextMeshProUGUI>())
            {
                textPart.text = cardModel.CardName;
            }
            _cardContentImage.sprite = cardModel.CardSprite;
            _button.onClick.AddListener(() =>
                {
                    menuSceneController.LoadScene(cardModel.CardName);
                }
            );
        }
    }
}