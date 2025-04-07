using Code.Gameplay.Features.TargetCollection;
using Entitas;

namespace Code.Gameplay.Features.Projectiles.Systems
{
   public sealed class FinalizeProcessedArmamentsSystem : ICleanupSystem
   {
      private readonly IGroup<GameEntity> _armaments;

      public FinalizeProcessedArmamentsSystem(GameContext game)
      {
         _armaments = game.GetGroup(GameMatcher
            .AllOf(
               GameMatcher.Projectile,
               GameMatcher.Processed));
      }

      public void Cleanup()
      {
         foreach (GameEntity armament in _armaments)
         {
            armament.RemoveTargetCollectionComponents();
            armament.isDestructed = true;
         }
      }
   }
}