using Entitas;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Splines;

namespace Code.Gameplay.Features.Splines.Systems
{
   public sealed class EvaluateThroughSplineSystem : IExecuteSystem
   {
      private readonly IGroup<GameEntity> _movers;

      public EvaluateThroughSplineSystem(GameContext context)
      {
         _movers = context.GetGroup(GameMatcher
            .AllOf(
               GameMatcher.Transform,
               GameMatcher.MovingSpline,
               GameMatcher.Spline,
               GameMatcher.SplineTPosition,
               GameMatcher.WorldPosition,
               GameMatcher.WorldRotation
            ));
      }

      public void Execute()
      {
         foreach (GameEntity mover in _movers)
         {
            mover.Spline.Evaluate(mover.SplineTPosition, out float3 position, out float3 tangent, out float3 upVector);
            
            mover.ReplaceWorldPosition(position);
            mover.ReplaceWorldRotation(Quaternion.LookRotation(mover.Transform.up, tangent));
            //mover.ReplaceWorldRotation(Quaternion.LookRotation(mover.Transform.up, Vector3.forward));
         }
      }
   }
}