using System;
using System.Threading;
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
            var bulletController = new BulletController(_data.BulletData);
            var uiController = new UiController(menu, uiView);
            var playerController = new PlayerController(_data.PlayerData);
            var cameraController = new CameraController(_data.CameraData);
            var spawnPointController = new SpawnPointController(_data.SpawnPointData);
            var bonusController = new BonusController(_data.BonusData);
            var enemyController = new EnemyController(_data.EnemyData);
            _controllerMaster = new ControllerMaster();
            _controllerMaster.Add(playerController);
            _controllerMaster.Add(cameraController);
            _controllerMaster.Add(spawnPointController);
            _controllerMaster.Add(bonusController);
            _controllerMaster.Add(uiController);
            _controllerMaster.Add(enemyController);
            _controllerMaster.Add(bulletController);
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
