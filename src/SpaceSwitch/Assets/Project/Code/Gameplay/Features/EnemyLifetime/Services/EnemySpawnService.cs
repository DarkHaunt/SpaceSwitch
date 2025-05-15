using System.Collections.Generic;
using Code.Common.Extensions;
using Code.Gameplay.Common.Time;
using Code.Gameplay.Features.EnemyLifetime.Factories;
using Code.Gameplay.StaticData;
using Project.Code.Gameplay.Features.Enemy.Configs;
using Project.Code.Gameplay.Features.EnemyLifetime.Configs;
using UnityEngine;
using VContainer.Unity;

namespace Code.Gameplay.Features.Enemy.Services
{
   public class EnemySpawnService : ITickable
   {
      private readonly EnemyScenarioFactory _factory;
      private readonly ITimeService _time;
      private readonly IStaticDataService _staticData;

      private float _lastPassedTime;
      private bool _isSpawning;

      private EnemySpawnConfig _spawnConfig;
      private Queue<EnemySpawnScenario> _currentScenarios = new Queue<EnemySpawnScenario>();

      private EnemySpawnScenario _nextScenario;


      public EnemySpawnService(EnemyScenarioFactory factory, ITimeService time, IStaticDataService staticData)
      {
         _factory = factory;
         _time = time;
         _staticData = staticData;
      }

      public void StartEnemySpawning()
      {
         RefreshNewScenarios();

         _nextScenario = _currentScenarios.Dequeue();
         _lastPassedTime = _nextScenario.TimeToSpawn;
         
         _isSpawning = true;
      }
      
      public void StopEnemySpawning()
      {
         _isSpawning = false;
      }

      public void Tick()
      {
         if(_isSpawning == false) 
            return;
         
         _lastPassedTime += _time.DeltaTime;
         
         if (_lastPassedTime >= _nextScenario.TimeToSpawn)
         {
            _factory.CreateSpawnScenario(_nextScenario);
            
            _lastPassedTime = 0;
            _nextScenario = _currentScenarios.Dequeue();

            if (_currentScenarios.Count == 0)
               RefreshNewScenarios();
         }
      }

      private void RefreshNewScenarios()
      {
         _spawnConfig = _staticData.EnemySpawnSpawnConfigs.PickRandom();
         
         _currentScenarios.Clear();
         _currentScenarios = new Queue<EnemySpawnScenario>(_spawnConfig.SpawnScenarios);
         
         _nextScenario = _currentScenarios.Peek();
      }
   }
}