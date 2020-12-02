using System.Collections.Generic;
using Data;
using Interactive;
using Interface;
using UnityEngine;

namespace Controller
{
    public class BonusController : IInitialization, IExecution
    {
        private PlayerController _playerController;
        private BonusData _bonusData;
        private List<GameObject> _bonuses;

        public BonusController(PlayerController playerController, BonusData bonusData)
        {
            _playerController = playerController;
            _bonusData = bonusData;
        }

        public void Initialize()
        {
            _bonuses = new List<GameObject>();
            GameObject[] spawnPoints = GameObject.FindGameObjectsWithTag("SpawnPoint");
            for (var i = 0; i < spawnPoints.Length; i++)
            {
                var spawnPoint = spawnPoints[i];
                GameObject gameObject;
                if (i % 2 != 0)
                {
                    gameObject = GameObject.Instantiate(_bonusData.goodBonus, spawnPoint.transform.position,
                        Quaternion.identity);
                }
                else
                {
                    gameObject = GameObject.Instantiate(_bonusData.badBonus, spawnPoint.transform.position,
                        Quaternion.identity);
                }

                var bonus = gameObject.GetComponent<InteractiveObject>();
                bonus.SetPlayerController(_playerController);
            }
        }

        public void Execute(float deltaTime)
        {
        }
    }
}