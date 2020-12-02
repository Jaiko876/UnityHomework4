using Camera;
using Data;
using Interface;
using UnityEngine;

namespace Controller
{
    public sealed class CameraController : IInitialization, IExecution
    {
        private CameraService _cameraService;
        
        public CameraController(CameraData cameraData, PlayerData playerData)
        {
            _cameraService = new CameraService(cameraData, playerData);
        }
        public void Initialize()
        {
            _cameraService.Initialize();
        }
        public void Execute(float deltaTime)
        {
            _cameraService.Execute(deltaTime);
        }
    }
}
