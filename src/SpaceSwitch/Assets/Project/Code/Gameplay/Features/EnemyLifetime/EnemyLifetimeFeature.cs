using Code.Gameplay.Features.Enemy.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.EnemyLifetime
{
   public sealed class EnemyLifetimeFeature : Feature
   {
      public EnemyLifetimeFeature(ISystemFactory systems)
      {
         Add(systems.Create<ProcessEnemySpawnQueueSystem>());
         
         Add(systems.Create<CleanupEnemyOnSplineEndSystem>());
         Add(systems.Create<CleanupEnemySpawnersWithEmptyQueueSystem>());
      }
   }
}