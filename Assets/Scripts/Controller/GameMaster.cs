using System;
using UnityEngine;

namespace Controller
{
    public sealed class GameMaster : MonoBehaviour
    {
        [SerializeField] private Data.Data _data;
        private ControllerMaster _controllerMaster;
        private void Start()
        {
            _data.PlayerData.player = GameObject.FindWithTag("Player");
            var playerController = new PlayerController(_data.PlayerData);
            var cameraController = new CameraController(_data.CameraData, _data.PlayerData);
            var bonusController = new BonusController(playerController, _data.BonusData);
            _controllerMaster = new ControllerMaster();
            _controllerMaster.Add(playerController);
            _controllerMaster.Add(cameraController);
            _controllerMaster.Add(bonusController);
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

        /*private void SpawnBonuses()
        {
            GameObject[] spawnPoints = GameObject.FindGameObjectsWithTag("SpawnPoint");
            foreach (var spawnPoint in spawnPoints)
            {
                Instantiate(_data.BonusData.gameObject, spawnPoint.transform.position, Quaternion.identity);
            }
        }*/
    }
}
