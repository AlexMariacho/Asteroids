using UnityEngine;

namespace Asteroids
{
    public sealed class Bootstrap : MonoBehaviour
    {
        [SerializeField] private GameSetting _gameSetting;
        
        private IUpdater _updater;
        private PlayerInputActions _playerInput;

        private void Awake()
        {
            _playerInput = new PlayerInputActions();
            _updater = new Updater(_gameSetting.FrameRate);

        }

        private void OnDestroy()
        {
        }
    }
}


    