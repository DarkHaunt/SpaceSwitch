using System.Collections.Generic;
using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Infrastructure.Identifiers;
using Project.Code.Gameplay.Features.Enemy.Configs;
using Project.Code.Gameplay.Features.EnemyLifetime.Configs;
using UnityEngine.Splines;

namespace Code.Gameplay.Features.EnemyLifetime.Factories
{
   public class EnemyScenarioFactory
   {
      private readonly IIdentifierService _identifiers;

      public EnemyScenarioFactory(IIdentifierService identifiers)
      {
         _identifiers = identifiers;
      }

      public GameEntity CreateSpawnScenario(EnemySpawnScenario scenario)
      {
         var firstTimer = scenario.Enemies[0].TimeToSpawn;
         
         return CreateGameEntity.Empty()
               .AddId(_identifiers.Next())
               
               .AddSpline(scenario.Spline.Spline)
               .AddEnemySpawnTimer(firstTimer)
               .AddEnemySpawnTimeLeft(firstTimer)
               .AddEnemySpawnQueue(new Queue<EnemySpawnData>(scenario.Enemies))

               .With(x => x.isEnemySpawnScenario = true)
               .With(x => x.isSpawningEnemies = true)
         ;
      }
   }
}