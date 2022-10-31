using System;
using UnityEngine;
using UnityEngine.UI;

namespace Asteroids.Core.Views
{
    public class StartGamePanel : MonoBehaviour
    {
        public event Action StartGameClick;
        
        [SerializeField] private Button _startGameButton;

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