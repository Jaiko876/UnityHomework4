using System.Collections;
using Data;
using Interface;
using UnityEngine;

namespace Camera
{
    public class CameraService : IExecution
    {
        private CameraData _cameraData;
        private PlayerData _playerData;
        private float _smoothTime;
        private UnityEngine.Camera _camera;

        private Vector3 _velocity;

        public CameraService(CameraData cameraData, PlayerData playerData)
        {
            _cameraData = cameraData;
            _playerData = playerData;
            _camera = UnityEngine.Camera.main;
            _velocity = Vector3.zero;
            _smoothTime = _cameraData._smoothTime;
        }

        public void Execute(float deltaTime)
        {
            FollowTarget();
        }

        private void FollowTarget()
        {
            Vector3 goalPos = _playerData.player.transform.position;
            goalPos.y = _playerData.player.transform.position.y + 24f;
            _camera.transform.position =
                Vector3.SmoothDamp(_camera.transform.position, goalPos, ref _velocity, _smoothTime);
        }
    }
}