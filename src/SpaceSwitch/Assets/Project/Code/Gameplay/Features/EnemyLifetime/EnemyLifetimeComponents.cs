using System.Collections.Generic;
using Entitas;
using Project.Code.Gameplay.Features.Enemy.Configs;

namespace Code.Gameplay.Features.EnemyLifetime
{
   [Game] public class SpawningEnemies : IComponent { }
   [Game] public class EnemySpawnScenarioComponent : IComponent { }
   [Game] public class EnemySpawnerComponent : IComponent { }
   [Game] public class EnemySpawnTimer : IComponent { public float Value; }
   [Game] public class EnemySpawnTimeLeft : IComponent { public float Value; }
   [Game] public class ReadyToSpawnNextEnemy : IComponent { }
   [Game] public class EnemySpawnQueueComponent : IComponent { public Queue<EnemySpawnData> Value; }
}