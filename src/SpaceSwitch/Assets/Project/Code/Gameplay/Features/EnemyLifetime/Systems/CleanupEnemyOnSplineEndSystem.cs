using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Enemy.Systems
{
   public sealed class CleanupEnemyOnSplineEndSystem : ICleanupSystem
   {
      private readonly IGroup<GameEntity> _enemies;
      private readonly List<GameEntity> _buffer = new(16);

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
         foreach (GameEntity enemy in _enemies.GetEntities(_buffer))
            enemy.isDestructed = true;
      }
   }
}