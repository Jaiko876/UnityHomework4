using Data;
using Interface;

namespace Player
{
    public class PlayerActionService : ITrigger, IExecution
    {
        private PlayerData _playerData;
        private float _bonusActiveTime;
        private float _defaultSpeed;
        public PlayerActionService(PlayerData playerData)
        {
            _playerData = playerData;
            _bonusActiveTime = 0f;
            _defaultSpeed = playerData._speed;
        }
        
        public void Execute(float deltaTime)
        {
            if (_bonusActiveTime > 0f)
            {
                _bonusActiveTime -= deltaTime;
            }
            else
            {
                _playerData._speed = _defaultSpeed;
            }
        }

        public void Interact(float value)
        {
            _playerData._speed = _defaultSpeed;
            _playerData._speed += value;
            _bonusActiveTime += 2f;
        }
    }
}
