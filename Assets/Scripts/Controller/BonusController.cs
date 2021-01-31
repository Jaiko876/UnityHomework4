using System.Collections.Generic;
using Data;
using Enum;
using Fabric;
using Interactive;
using Interface;
using UnityEngine;

namespace Controller
{
    public class BonusController : IInitialization, IExecution
    {
        private PlayerController _playerController;
        private UiController _uiController;
        private SpawnPointController _spawnPointController;
        private BonusData _bonusData;
        private List<GameObject> _bonuses;

        public BonusController(BonusData bonusData)
        {
            _bonusData = bonusData;
        }

        public void Initialize()
        {
            _playerController = (PlayerController) ControllerMaster.InjectController(typeof(PlayerController));
            _uiController = (UiController) ControllerMaster.InjectController(typeof(UiController));
            _spawnPointController = (SpawnPointController) ControllerMaster.InjectController(typeof(SpawnPointController));
            
            InitializeBonuses();
        }

        public void Execute(float deltaTime)
        {
        }

        private void InitializeBonuses()
        {
            var bonusFabric = new BonusFabric(_bonusData);
            _bonuses = new List<GameObject>();
            var spawnPoints = _spawnPointController.Data.BonusSpawnPoints;

            foreach (var spawnPoint in spawnPoints)
            {
                GameObject gameObject = null;
                if (spawnPoint.Type == BonusEnum.SPEED_BUF)
                {
                    gameObject = bonusFabric.Instantiate(BonusEnum.SPEED_BUF, spawnPoint.transform.position,
                        Quaternion.identity);
                }
                else if (spawnPoint.Type == BonusEnum.SPEED_DEBUF)
                {
                    gameObject = bonusFabric.Instantiate(BonusEnum.SPEED_DEBUF, spawnPoint.transform.position,
                        Quaternion.identity);
                }

                if (gameObject == null) continue;
                var bonus = gameObject.GetComponent<InteractiveObject<BonusData>>();
                SignControllers(bonus, _playerController, _uiController);
                bonus.SetData(_bonusData);
                _bonuses.Add(gameObject);
            }
        }
        
        private void SignControllers(InteractiveObject<BonusData> bonus, params ITrigger[] triggers)
        {
            foreach (var controller in triggers)
            {
                bonus.AddController(controller);
            }
        }
    }
}