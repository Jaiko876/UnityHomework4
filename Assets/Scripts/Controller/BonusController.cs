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
        private UIController _uiController;
        private SpawnPointController _spawnPointController;
        private BonusData _bonusData;
        private List<GameObject> _bonuses;

        public BonusController(PlayerController playerController, UIController uiController, SpawnPointController spawnPointController, BonusData bonusData)
        {
            _playerController = playerController;
            _uiController = uiController;
            _spawnPointController = spawnPointController;
            _bonusData = bonusData;
        }

        public void Initialize()
        {
            var bonusFabric = new BonusFabric(_bonusData);
            _bonuses = new List<GameObject>();
            var spawnPoints = _spawnPointController.Data.SpawnPoints;

            foreach (var spawnPoint in spawnPoints)
            {
                GameObject gameObject = null;
                if (spawnPoint.Type == SpawnPointTypeEnum.SPEED_BUF)
                {
                    gameObject = bonusFabric.Instantiate(BonusEnum.GOOD_BONUS, spawnPoint.transform.position,
                        Quaternion.identity);
                }
                else if (spawnPoint.Type == SpawnPointTypeEnum.SPEED_DEBUF)
                {
                    gameObject = bonusFabric.Instantiate(BonusEnum.BAD_BONUS, spawnPoint.transform.position,
                        Quaternion.identity);
                }

                if (gameObject == null) continue;
                var bonus = gameObject.GetComponent<InteractiveObject<BonusData>>();
                SignControllers(bonus, _playerController, _uiController);
                bonus.SetData(_bonusData);
                _bonuses.Add(gameObject);
            }
        }

        public void Execute(float deltaTime)
        {
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