using Data;
using Interface;
using UnityEngine;

namespace Player
{
    public sealed class PlayerMovementService : IInitialization, IExecution, ILateExecution, ICleanup
    {
        private PlayerData _playerData;
        private Vector3 _inputs;
        private Rigidbody _rigidbody;
        private UnityEngine.Camera _camera;
        private Transform _transform;
        
        public PlayerMovementService(PlayerData playerData)
        {
            _playerData = playerData;
        }
        public void Initialize()
        {
            _camera = UnityEngine.Camera.main;
            _inputs = Vector3.zero;
            _rigidbody = _playerData.player.GetComponent<Rigidbody>();
            _transform = _playerData.player.transform;
        }

        public void Execute(float deltaTime)
        {
            ReadInput();
            LookAtMouse();
        }

        public void LateExecute(float deltaTime)
        {
            Move(deltaTime);
        }

        public void Cleanup()
        {
        }

        private void ReadInput()
        {
            _inputs.x = Input.GetAxis("Horizontal");
            _inputs.z = Input.GetAxis("Vertical");
        }

        private void Move(float deltaTime)
        {
            if (_inputs != Vector3.zero)
            {
                _rigidbody.MovePosition(_rigidbody.position + _inputs * (_playerData._speed * deltaTime));
            }
            else
            {
                _rigidbody.velocity = Vector3.zero;
            }
        }
        
        private void LookAtMouse()
        {
            Ray cameraRay = _camera.ScreenPointToRay(Input.mousePosition);
            Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
            float rayLength;

            if (groundPlane.Raycast(cameraRay, out rayLength))
            {
                Vector3 pointToLook = cameraRay.GetPoint(rayLength);
                Debug.DrawLine(cameraRay.origin, pointToLook, Color.blue);
                _transform.LookAt(new Vector3(pointToLook.x, _transform.position.y, pointToLook.z));
            }
        }
    }
}
