using Entitas;

namespace Code.Gameplay.Features.Enemy.Systems
{
   public sealed class EnemyDestructOnSplineEndSystem : IExecuteSystem
   {
      private readonly IGroup<GameEntity> _enemies;

      public EnemyDestructOnSplineEndSystem(GameContext context)
      {
         _enemies = context.GetGroup(GameMatcher
            .AllOf(
               GameMatcher.Enemy,
               GameMatcher.MovingSpline,
               GameMatcher.ReachedSplineEnd
            )
            .NoneOf(GameMatcher.Destructed));
      }

      public void Execute()
      {
         foreach (GameEntity enemy in _enemies)
            enemy.isDestructed = true;
      }
   }
}