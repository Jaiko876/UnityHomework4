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
            GameObject[] spawnPoints = GameObject.FindGameObjectsWithTag("SpawnPoint");
            if (spawnPoints.Length == 0)
            {
                throw new Exception("Отсутствуют точки спауна бонусов");
            }
            foreach (var spawnPoint in spawnPoints)
            {
                SpawnPoint point = spawnPoint.GetComponent<SpawnPoint>();
                point.Position = spawnPoint.transform.position;
                _data.SpawnPoints.Add(point);
            }
        }

        public SpawnPointData Data => _data;
        public void Cleanup()
        {
            _data._spawnPoints = new List<SpawnPoint>();
        }
    }
}