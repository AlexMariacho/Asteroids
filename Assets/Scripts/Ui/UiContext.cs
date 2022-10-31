using System;
using UnityEngine;

namespace Asteroids.Core.Views
{
    public class UiContext : MonoBehaviour
    {
        public event Action StartGame;
        
        [SerializeField] private GameHud _gameHud;
        [SerializeField] private RestartGamePanel _restartGamePanel;
        [SerializeField] private StartGamePanel _startGamePanel;

        private void OnEnable()
        {
            _restartGamePanel.StartGameClick += OnStartGameEvent;
            _startGamePanel.StartGameClick += OnStartGameEvent;
        }

        private void OnDisable()
        {
            _restartGamePanel.StartGameClick -= OnStartGameEvent;
            _startGamePanel.StartGameClick -= OnStartGameEvent;
        }

        private void OnStartGameEvent()
        {
            StartGame?.Invoke();
        }

        public void ShowStartGamePanel()
        {
            _startGamePanel.gameObject.SetActive(true);
            _restartGamePanel.gameObject.SetActive(false);
            _gameHud.gameObject.SetActive(false);
        }

        public void ShowRestartGamePanel(int score)
        {
            _startGamePanel.gameObject.SetActive(false);
            _restartGamePanel.gameObject.SetActive(true);
            _gameHud.gameObject.SetActive(false);
            
            _restartGamePanel.ShowScore(score);
        }

        public void ShowGameHud()
        {
            _startGamePanel.gameObject.SetActive(false);
            _restartGamePanel.gameObject.SetActive(false);
            _gameHud.gameObject.SetActive(true);
        }

    }
}