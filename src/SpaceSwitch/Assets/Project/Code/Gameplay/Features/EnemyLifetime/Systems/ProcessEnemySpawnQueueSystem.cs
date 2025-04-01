using Entitas;
using Project.Code.Gameplay.Features.Enemy.Configs;

namespace Code.Gameplay.Features.Enemy.Systems
{
   public sealed class ProcessEnemySpawnQueueSystem : IExecuteSystem
   {
      private readonly EnemyFactory _factory;
      private readonly IGroup<GameEntity> _spawners;

      public ProcessEnemySpawnQueueSystem(GameContext context, EnemyFactory factory)
      {
         _factory = factory;
         _spawners = context.GetGroup(GameMatcher
            .AllOf(
               GameMatcher.EnemySpawnQueue,
               GameMatcher.SpawningEnemies,
               GameMatcher.ReadyToSpawnNextEnemy
            ));
      }

      public void Execute()
      {
         foreach (GameEntity spawner in _spawners)
         {
            EnemySpawnData nextEnemy = spawner.EnemySpawnQueue.Dequeue();
            
            //_factory.CreateEnemy(nextEnemy.TypeId, nextEnemy.Spline);
            
            spawner.isReadyToSpawnNextEnemy = false;
         }
      }
   }
}