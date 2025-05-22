using Code.Gameplay.Features.Enemy.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Enemy
{
   public sealed class EnemyFeature : Feature
   {
      public EnemyFeature(ISystemFactory systems)
      {
         Add(systems.Create<EnemyShootSystem>());
         
         Add(systems.Create<EnemyDeathSystem>());
         Add(systems.Create<EnemyAddScoreOnDeathSystem>());
      }
   }
}