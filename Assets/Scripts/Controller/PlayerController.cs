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
        private UIController _uiController;

        public PlayerController(UIController uiController, PlayerData playerData)
        {
            _playerMovementService = new PlayerMovementService(playerData);
            _playerActionService = new PlayerActionService(uiController, playerData);
            _uiController = uiController;
        }
        public void Initialize()
        {
            _playerMovementService.Initialize();
            _uiController.UiView.DefaultSpeedValue = _playerActionService.DefaultSpeed;
        }

        public void Execute(float deltaTime)
        {
            if (_uiController.IsPaused()) return;
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
            _playerActionService.Cleanup();
        }

        public void Interact(float value)
        {
            _playerActionService.Interact(value);
        }
    }
}
