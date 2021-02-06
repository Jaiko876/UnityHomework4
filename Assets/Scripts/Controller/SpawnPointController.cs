using System;
using System.Collections.Generic;
using Data;
using Interface;
using SpawnPoints;
using UnityEngine;

namespace Controller
{
    public sealed class SpawnPointController : IInitialization, ICleanup
    {
        private SpawnPointData _data;

        public SpawnPointController(SpawnPointData data)
        {
            _data = data;
        }

        public void Initialize()
        {
            FindSpawnPoints();
        }

        public SpawnPointData Data => _data;
        public void Cleanup()
        {
            _data._bonusBonusSpawnPoints = new List<BonusSpawnPoint>();
            _data._enemySpawnPoints = new List<EnemySpawnPoint>();
        }
        
        private void FindSpawnPoints()
        {
            List<BonusSpawnPoint> bonusSpawnPoints = ObtainPoints<BonusSpawnPoint>("SpawnPoint");
            List<EnemySpawnPoint> enemySpawnPoints = ObtainPoints<EnemySpawnPoint>("EnemySpawnPoint");
            _data.BonusSpawnPoints.AddRange(bonusSpawnPoints);
            _data.EnemySpawnPoints.AddRange(enemySpawnPoints);
        }

        private List<T> ObtainPoints<T>(string tag)
        {
            GameObject[] spawnPoints = GameObject.FindGameObjectsWithTag(tag);
            List<T> points = new List<T>();
            if (spawnPoints.Length != 0)
            {

                foreach (var spawnPoint in spawnPoints)
                {
                    T point = spawnPoint.GetComponent<T>();
                    points.Add(point);
                }
            }

            return points;
        }
    }
}