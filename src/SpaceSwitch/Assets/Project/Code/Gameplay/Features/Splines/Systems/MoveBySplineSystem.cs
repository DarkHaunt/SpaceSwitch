using Code.Gameplay.Common.Time;
using Entitas;
using UnityEditor.Splines;
using UnityEngine;
using UnityEngine.Splines;

namespace Code.Gameplay.Features.Splines.Systems
{
   public sealed class MoveBySplineSystem : IExecuteSystem
   {
      private readonly ITimeService _time;
      private readonly IGroup<GameEntity> _movers;

      public MoveBySplineSystem(GameContext context, ITimeService time)
      {
         _time = time;
         _movers = context.GetGroup(GameMatcher
            .AllOf(
               GameMatcher.MovingSpline,
               GameMatcher.Spline,
               GameMatcher.SplineTPosition,
               GameMatcher.Speed
            ));
      }

      public void Execute()
      {
         foreach (GameEntity mover in _movers)
         {
            var incomeLength = mover.Speed * _time.DeltaTime;
            var tIncome = incomeLength / mover.Spline.GetLength();

            var t = Mathf.Clamp01(mover.SplineTPosition + tIncome);
            
            mover.ReplaceSplineTPosition(t);
         }
      }
   }
}