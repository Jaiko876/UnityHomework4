using Controller;
using Data;
using Interface;
using Interface.Gun;
using UnityEngine;
using Weapon;

namespace Player
{
    public class PlayerActionService : IExecution, ICleanup, IAlive
    {
        private UiController _uiController;
        private IGun _commonGun;
        private PlayerData _playerData;

        private float _bonusActiveTime;
        private float _defaultSpeed;
        private bool _isSpeedBonusTriggered;

        public PlayerActionService(UiController uiController, PlayerData playerData)
        {
            _uiController = uiController;
            
            _playerData = playerData;
            
            _commonGun = new CommonGun(_playerData.player.transform.Find("Gun").transform.Find("BulletSpawner"), _playerData._amountOfAmmo, _playerData._rateOfFire);
            _bonusActiveTime = 0f;
            _defaultSpeed = playerData._speed;
            _isSpeedBonusTriggered = false;
            SetHealthPoints(100f);
        }
        
        public void Execute(float deltaTime)
        {
            if (IsDead())
            {
                GameObject.Destroy(_playerData.player);
            }
            Shoot();
            checkBonusTrigger(deltaTime);
        }

        public void Interact(float value)
        {
            _playerData._speed = _defaultSpeed;
            _playerData._speed += value;
            _bonusActiveTime += 2f;
            _isSpeedBonusTriggered = true;
        }

        public void Cleanup()
        {
            _playerData._speed = _defaultSpeed;
        }

        public float DefaultSpeed
        {
            get => _defaultSpeed;
            set => _defaultSpeed = value;
        }

        public float GetHealthPoints()
        {
            return _playerData.health;
        }

        public void SetHealthPoints(float healthPoints)
        {
            _playerData.health = healthPoints;
        }

        public void TakeDamage(float damage)
        {
            var health = _playerData.health;
            _playerData.health = health - damage;
        }

        public bool IsDead()
        {
            return GetHealthPoints() <= 0;
        }

        private void Shoot()
        {
            _commonGun.CalculateNextShoot();
            if (Input.GetButtonDown("Fire1"))
            {
               _commonGun.Shoot();
            }
        }
        
        private void checkBonusTrigger(float deltaTime)
        {
            if (_isSpeedBonusTriggered)
            {
                if (_bonusActiveTime > 0f)
                {
                    _bonusActiveTime -= deltaTime;
                }
                else
                {
                    _playerData._speed = _defaultSpeed;
                    _uiController.Interact(0);
                    _isSpeedBonusTriggered = false;
                }
            }
        }
    }
}
