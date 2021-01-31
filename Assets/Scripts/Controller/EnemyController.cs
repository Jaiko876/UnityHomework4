using System.Collections.Generic;
using Data;
using Entity;
using Enum;
using Fabric;
using Interactive;
using Interface;
using Interface.Gun;
using UnityEngine;
using UnityEngine.AI;
using View;
using Weapon;

namespace Controller
{
    public class EnemyController : IInitialization, IExecution, ILateExecution, ICleanup
    {
        private SpawnPointController _spawnPointController;

        private EnemyData _enemyData;
        private List<CommonEnemy> _enemies;
        
        private LayerMask _playerLayer;
        private LayerMask _obstacleLayer;

        private bool _seeingPlayer;

        public EnemyController(EnemyData enemyData)
        {
            _enemyData = enemyData;
        }
        public void Initialize()
        {
            _spawnPointController = (SpawnPointController) ControllerMaster.InjectController(typeof(SpawnPointController));
            InitializeEnemies();
            _playerLayer = LayerMask.GetMask("Player");
            _obstacleLayer = LayerMask.GetMask("Default");
        }

        public void Execute(float deltaTime)
        {
            foreach (var enemy in _enemies)
            {
                if (enemy.IsDead())
                {
                    enemy.EnemyView.SetActive(false);
                }

                if (!enemy.EnemyView.activeSelf) continue;
                LookForPlayer(enemy);
                enemy.Gun.CalculateNextShoot();
            }
        }

        public void LateExecute(float deltaTime)
        {
        }

        public void Cleanup()
        {
        }
        
        public List<CommonEnemy> Enemies => _enemies;

        private void InitializeEnemies()
        {
            var enemyFabric = new EnemyFabric(_enemyData);
            _enemies = new List<CommonEnemy>();
            var spawnPoints = _spawnPointController.Data.EnemySpawnPoints;

            foreach (var spawnPoint in spawnPoints)
            {
                var enemy = enemyFabric.Instantiate(spawnPoint.Type, spawnPoint.transform.position,
                    Quaternion.identity);
                
                if (enemy == null) continue;

                var commonEnemy = new CommonEnemy();
                commonEnemy.EnemyView = enemy;
                commonEnemy.Gun = new CommonGun(enemy.transform.Find("Gun").transform.Find("BulletSpawner"), _enemyData._amountOfAmmo, _enemyData._rateOfFire);
                commonEnemy.NavMeshAgent = enemy.GetComponent<NavMeshAgent>();
                _enemies.Add(commonEnemy);
            }
        }
        
        private void LookForPlayer(CommonEnemy enemy)
        {
            Collider[] targets = Physics.OverlapSphere(enemy.EnemyView.transform.position, _enemyData._radiusOfView, _playerLayer);

            for (int i = 0; i < targets.Length; i++)
            {
                Transform target = targets[i].transform;
                Vector3 dirToTarget = (target.position - enemy.EnemyView.transform.position).normalized;
                Debug.DrawRay(target.position, enemy.EnemyView.transform.position - target.position, Color.red);    
                if (Vector3.Angle(enemy.EnemyView.transform.forward, dirToTarget) < _enemyData._viewAngle / 2)
                {
                    float distanceToTarget = Vector3.Distance(enemy.EnemyView.transform.position, target.position);
                    if (!Physics.Raycast(enemy.EnemyView.transform.position, dirToTarget, distanceToTarget, _obstacleLayer))
                    {
                        _seeingPlayer = true;
                        Attack(target, enemy);
                    }
                    else
                    {
                        _seeingPlayer = false; 
                    }
                }
            }
        }

        private void Attack(Transform player, CommonEnemy enemy) 
        {
            enemy.EnemyView.transform.LookAt(player);
            enemy.NavMeshAgent.SetDestination(player.position);
            enemy.Gun.Shoot();
        }
    }
}