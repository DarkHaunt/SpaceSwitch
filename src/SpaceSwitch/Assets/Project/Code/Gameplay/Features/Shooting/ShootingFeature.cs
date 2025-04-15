using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Shooting.Systems
{
   public sealed class ShootingFeature : Feature
   {
      public ShootingFeature(ISystemFactory systems)
      {
         Add(systems.Create<ShootingCooldownProcessSystem>());
      }
   }
}