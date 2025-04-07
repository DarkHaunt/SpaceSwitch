using Code.Gameplay.Features.Projectiles.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Projectiles
{
   public sealed class ProjectileFeature : Feature
   {
      public ProjectileFeature(ISystemFactory systems)
      {
         Add(systems.Create<MarkProcessedOnTargetLimitExceededSystem>());
         Add(systems.Create<FinalizeProcessedArmamentsSystem>());
      }
   }
}