using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Enemy.Systems
{
   public sealed class CleanupEnemySpawnersWithEmptyQueueSystem : ICleanupSystem
   {
      private readonly IGroup<GameEntity> _spawners;
      private readonly List<GameEntity> _buffer = new(4);

      public CleanupEnemySpawnersWithEmptyQueueSystem(GameContext context)
      {
         _spawners = context.GetGroup(GameMatcher
            .AllOf(
               GameMatcher.EnemySpawnQueue,
               GameMatcher.EnemySpawner,
               GameMatcher.SpawningEnemies
            )
            .NoneOf(GameMatcher.Destructed));
      }

      public void Cleanup()
      {
         foreach (GameEntity spawner in _spawners.GetEntities(_buffer))
         {
            if (spawner.EnemySpawnQueue.Count == 0)
               spawner.isDestructed = true;
         }
      }
   }
}