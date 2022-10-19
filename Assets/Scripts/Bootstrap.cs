using System;
using Asteroids.Settings;
using UnityEngine;

namespace Asteroids
{
    public sealed class Bootstrap : MonoBehaviour
    {
        [SerializeField] private GameSetting _gameSetting;
        
        private IUpdater _updater;

        private void Awake()
        {
            _updater = new Updater(_gameSetting.FrameRate);
            _updater.UpdateEvent += OnUpdateEvent;
            _updater.Start();
        }

        private void OnDestroy()
        {
            _updater.UpdateEvent -= OnUpdateEvent;
            _updater.Stop();
        }

        private void OnUpdateEvent()
        {
            Debug.Log("TEST");
        }
    }
}


    