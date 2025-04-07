using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Splines.Systems
{
   public sealed class MarkReachedSplineMoversSystem : IExecuteSystem
   {
      private readonly IGroup<GameEntity> _movers;
      private readonly List<GameEntity> _buffer = new(16);

      public MarkReachedSplineMoversSystem(GameContext context)
      {
         _movers = context.GetGroup(GameMatcher
            .AllOf(
               GameMatcher.MovingSpline,
               GameMatcher.SplineTPosition
            )
            .NoneOf
            (
               GameMatcher.ReachedSplineEnd
            ));
      }

      public void Execute()
      {
         foreach (GameEntity entity in _movers.GetEntities(_buffer))
         {
            if(entity.SplineTPosition >= 1)
               entity.isReachedSplineEnd = true;
         }
      }
   }
}