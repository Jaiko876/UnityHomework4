using Controller;
using Data;
using Interface;

namespace Player
{
    public class PlayerActionService : IExecution, ICleanup
    {
        private UiController _uiController;
        private PlayerData _playerData;
        private float _bonusActiveTime;
        private float _defaultSpeed;
        private bool _isSpeedBonusTriggered;
        
        public PlayerActionService(UiController uiController, PlayerData playerData)
        {
            _uiController = uiController;
            _playerData = playerData;
            _bonusActiveTime = 0f;
            _defaultSpeed = playerData._speed;
            _isSpeedBonusTriggered = false;
        }
        
        public void Execute(float deltaTime)
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
    }
}
