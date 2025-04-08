using Code.Gameplay.Features.TargetCollection;
using Entitas;

namespace Code.Gameplay.Features.Projectiles.Systems
{
   public sealed class FinalizeProcessedProjectilesSystem : ICleanupSystem
   {
      private readonly IGroup<GameEntity> _projectiles;

      public FinalizeProcessedProjectilesSystem(GameContext game)
      {
         _projectiles = game.GetGroup(GameMatcher
            .AllOf(
               GameMatcher.Projectile,
               GameMatcher.Processed));
      }

      public void Cleanup()
      {
         foreach (GameEntity armament in _projectiles)
         {
            armament.RemoveTargetCollectionComponents();
            armament.isDestructed = true;
         }
      }
   }
}