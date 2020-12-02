using System;
using Data;
using Interface;
using Player;

namespace Controller
{
    public sealed class PlayerController : IInitialization, IExecution, ILateExecution, ICleanup, ITrigger
    {
        private PlayerMovementService _playerMovementService;
        private PlayerActionService _playerActionService;

        public PlayerController(PlayerData playerData)
        {
            _playerMovementService = new PlayerMovementService(playerData);
            _playerActionService = new PlayerActionService(playerData);
        }
        public void Initialize()
        {
            _playerMovementService.Initialize();
        }

        public void Execute(float deltaTime)
        {
            _playerMovementService.Execute(deltaTime);
            _playerActionService.Execute(deltaTime);
        }

        public void LateExecute(float deltaTime)
        {
            _playerMovementService.LateExecute(deltaTime);
        }

        public void Cleanup()
        {
            _playerMovementService.Cleanup();
        }

        public void BonusEnter(float value)
        {
            _playerActionService.BonusEnter(value);
        }
    }
}
