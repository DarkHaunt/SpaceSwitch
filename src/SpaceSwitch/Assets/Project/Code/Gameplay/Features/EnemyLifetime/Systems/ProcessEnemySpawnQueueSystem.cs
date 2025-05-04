using System.Collections.Generic;
using Code.Gameplay.Common.Time;
using Entitas;
using Project.Code.Gameplay.Features.Enemy.Configs;
using UnityEngine;

namespace Code.Gameplay.Features.Enemy.Systems
{
   public sealed class ProcessEnemySpawnQueueSystem : IExecuteSystem
   {
      private readonly EnemyFactory _factory;
      private readonly ITimeService _time;
      private readonly IGroup<GameEntity> _spawners;

      public ProcessEnemySpawnQueueSystem(GameContext context, EnemyFactory factory, ITimeService time)
      {
         _factory = factory;
         _time = time;
         _spawners = context.GetGroup(GameMatcher
            .AllOf(
               GameMatcher.SpawningEnemies,
               GameMatcher.EnemySpawnQueue,
               GameMatcher.EnemySpawnTimeLeft,
               GameMatcher.Spline,
               GameMatcher.EnemySpawnTimer
            ).NoneOf(GameMatcher.Destructed));
      }

      public void Execute()
      {
         foreach (GameEntity spawner in _spawners)
         {
            spawner.ReplaceEnemySpawnTimeLeft(spawner.EnemySpawnTimeLeft - _time.DeltaTime);
            
            if(spawner.EnemySpawnTimeLeft > 0) 
               continue;
            
            EnemySpawnData nextEnemy = spawner.EnemySpawnQueue.Dequeue();
            spawner.ReplaceEnemySpawnTimeLeft(nextEnemy.TimeToSpawn);

            _factory.CreateEnemy(nextEnemy, spawner.Spline);
         }
      }
   }
}