using System;
using UnityEngine;

namespace Menu.Models
{
    [CreateAssetMenu(menuName = "Menu/Add Card Model")]
    public class CardModel: ScriptableObject
    {
        [Header("Data")]
        [HideInInspector] public string CardName;
        public int UserScore;
        public int MaxScore;

        [Header("Sprites")]
        public Sprite CardSprite;

        private void OnValidate() => CardName = this.name;
    }
}