using System.Collections.Generic;
using Code.Gameplay.Features.TargetCollection;
using Entitas;

namespace Code.Gameplay.Features.Projectiles.Systems
{
   public sealed class FinalizeProcessedProjectilesSystem : ICleanupSystem
   {
      private readonly IGroup<GameEntity> _projectiles;
      private readonly List<GameEntity> _buffer = new(16);

      public FinalizeProcessedProjectilesSystem(GameContext game)
      {
         _projectiles = game.GetGroup(GameMatcher
            .AllOf(
               GameMatcher.Projectile,
               GameMatcher.Processed)
            .NoneOf(GameMatcher.Dead));
      }

      public void Cleanup()
      {
         foreach (GameEntity armament in _projectiles.GetEntities(_buffer))
         {
            armament.RemoveTargetCollectionComponents();
            armament.isDead = true;
            armament.isProcessingDeath = true;
         }
      }
   }
}