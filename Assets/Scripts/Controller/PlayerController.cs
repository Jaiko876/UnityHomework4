using System;
using Data;
using Enum;
using Interactive;
using Interface;
using Player;

namespace Controller
{
    public sealed class PlayerController : IInitialization, IExecution, ILateExecution, ICleanup, ITrigger
    {
        private PlayerMovementService _playerMovementService;
        private PlayerActionService _playerActionService;
        private UiController _uiController;
        private CameraController _cameraController;

        private PlayerData _playerData;

        public PlayerController(PlayerData playerData)
        {
            _playerData = playerData;
        }
        public void Initialize()
        {
            _uiController = (UiController) ControllerMaster.InjectController(typeof(UiController));
            _cameraController = (CameraController) ControllerMaster.InjectController(typeof(CameraController));

            _playerMovementService = new PlayerMovementService(_playerData);
            _playerActionService = new PlayerActionService(_uiController, _playerData);
            
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

        public PlayerData GetData()
        {
            return _playerData;
        }
        
        public PlayerActionService PlayerActionService => _playerActionService;

    }
}
