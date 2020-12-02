using System.Collections.Generic;
using Interactive;
using Interface;
using UnityEngine;
using UnityEngine.EventSystems;

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
            foreach (var spawnPoint in spawnPoints)
            {
                var gameObject = GameObject.Instantiate(_bonusData.gameObject, spawnPoint.transform.position,
                    Quaternion.identity);
                var goodBonus = gameObject.GetComponent<GoodBonus>();
                goodBonus.SetPlayerController(_playerController);
            }
        }

        public void Execute(float deltaTime)
        {
        }
    }
}