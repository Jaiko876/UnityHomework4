using Camera;
using Data;
using Enum;
using Interface;
using UnityEngine;

namespace Controller
{
    public sealed class CameraController : IInitialization, IExecution
    {
        private CameraService _cameraService;


        private CameraData _cameraData;
        
        public CameraController(CameraData cameraData)
        {
            _cameraData = cameraData;
        }
        public void Initialize()
        {
            PlayerController playerController = (PlayerController) ControllerMaster.InjectController(typeof(PlayerController));
            _cameraService = new CameraService(_cameraData, playerController.GetData());
        }
        public void Execute(float deltaTime)
        {
            _cameraService.Execute(deltaTime);
        }
        
        public CameraService CameraService => _cameraService;
    }
}
