using System;
using UI;
using UnityEngine;

namespace Controller
{
    public sealed class GameMaster : MonoBehaviour
    {
        [SerializeField] private Data.Data _data;
        private ControllerMaster _controllerMaster;
        private void Start()
        {
            var menu = gameObject.GetComponentInChildren<Menu>();
            var uiView = gameObject.GetComponentInChildren<UIView>();
            _data.PlayerData.player = GameObject.FindWithTag("Player");
            var uiController = new UIController(menu, uiView);
            var playerController = new PlayerController(uiController, _data.PlayerData);
            var cameraController = new CameraController(_data.CameraData, _data.PlayerData);
            var spawnPointController = new SpawnPointController(_data.SpawnPointData);
            var bonusController = new BonusController(playerController, uiController, spawnPointController, _data.BonusData);
            _controllerMaster = new ControllerMaster();
            _controllerMaster.Add(playerController);
            _controllerMaster.Add(cameraController);
            _controllerMaster.Add(spawnPointController);
            _controllerMaster.Add(bonusController);
            _controllerMaster.Add(uiController);
            _controllerMaster.Initialize();
        }

        private void Update()
        {
            var deltaTime = Time.deltaTime;
            _controllerMaster.Execute(deltaTime);
        }

        private void LateUpdate()
        {
            var deltaTime = Time.deltaTime;
            _controllerMaster.LateExecute(deltaTime);
        }

        private void OnDestroy()
        {
            _controllerMaster.Cleanup();
        }
    }
}
