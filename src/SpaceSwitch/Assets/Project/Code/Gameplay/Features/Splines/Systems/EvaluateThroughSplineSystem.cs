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
            
            float3 yAxis = math.normalize(tangent);
            float3 zAxis = math.normalize(mover.Transform.forward);

            float3 xAxis = math.normalize(math.cross(yAxis, zAxis));
            zAxis = math.cross(xAxis, yAxis);

            float3x3 rotationMatrix = new float3x3(xAxis, yAxis, zAxis);
            quaternion rotation = quaternion.LookRotationSafe(rotationMatrix.c2, rotationMatrix.c1);

            mover.ReplaceWorldPosition(position);
            mover.ReplaceWorldRotation(rotation);
         }
      }
   }
}