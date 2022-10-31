using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Asteroids.Core.Views
{
    public class RestartGamePanel : MonoBehaviour
    {
        public event Action StartGameClick;
        
        [SerializeField] private Button _startGameButton;
        [SerializeField] private TMP_Text _scoreText;

        public void ShowScore(int score)
        {
            _scoreText.text = $"Your score: {score}";
        }

        private void OnEnable()
        {
            _startGameButton.onClick.AddListener(OnClickButton);
        }

        private void OnDisable()
        {
            _startGameButton.onClick.RemoveListener(OnClickButton);
        }

        private void OnClickButton()
        {
            StartGameClick?.Invoke();
        }
    }
}