using Entitas;

namespace Code.Gameplay.Features.Enemy.Systems
{
   public sealed class CleanupEnemyOnSplineEndSystem : ICleanupSystem
   {
      private readonly IGroup<GameEntity> _enemies;

      public CleanupEnemyOnSplineEndSystem(GameContext context)
      {
         _enemies = context.GetGroup(GameMatcher
            .AllOf(
               GameMatcher.Enemy,
               GameMatcher.MovingSpline,
               GameMatcher.ReachedSplineEnd
            )
            .NoneOf(GameMatcher.Destructed));
      }

      public void Cleanup()
      {
         foreach (GameEntity enemy in _enemies)
            enemy.isDestructed = true;
      }
   }
}