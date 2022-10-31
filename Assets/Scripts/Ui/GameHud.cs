using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Asteroids.Core.Views
{
    public class GameHud : MonoBehaviour
    {
        private PlayerMover _playerMover;
        private LaserWeapon _laserWeapon;

        [SerializeField] private GameObject _reloadPanel;
        [SerializeField] private Image _reloadProgressImage;
        [SerializeField] private TMP_Text _chargeCount;
        
        [SerializeField] private TMP_Text _position;
        [SerializeField] private TMP_Text _rotation;
        [SerializeField] private TMP_Text _speed;

        public void Initialize(PlayerMover playerMover, LaserWeapon laserWeapon)
        {
            _playerMover = playerMover;
            _laserWeapon = laserWeapon;

            _playerMover.PositionChange += OnChangePosition;
            _playerMover.RotationChange += OnRotationChange;
            _playerMover.SpeedChange += OnSpeedChange;

            _laserWeapon.ChargeEvent += OnChargeCountEvent;
            _laserWeapon.ChargeTimeEvent += OnChargeLaserTimeEvent;
            
            OnChargeCountEvent(_laserWeapon.CurrentCharges);
        }

        private void OnChangePosition(Vector3 position)
        {
            _position.text = position.x.ToString("F1") + " / " + position.y.ToString("F1");
        }

        private void OnRotationChange(Vector3 rotation)
        {
            _rotation.text = rotation.z.ToString("F1");
        }

        private void OnSpeedChange(float speed)
        {
            _speed.text = speed.ToString("F1");
        }

        private void OnChargeCountEvent(int count)
        {
            _chargeCount.text = count.ToString();
        }

        private void OnChargeLaserTimeEvent(float reloadCharge)
        {
            if (Math.Abs(reloadCharge - 1) < 0.02f)
            {
                _reloadPanel.SetActive(false);
            }
            else
            {
                _reloadProgressImage.fillAmount = reloadCharge;
                _reloadPanel.SetActive(true);
            }
        }
    }
}