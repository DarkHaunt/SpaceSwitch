using Entitas;
using UnityEngine;

namespace Project.Code.Gameplay.Features.Cameras
{
   public sealed class CameraClampZSystem : IExecuteSystem
   {
      private readonly IGroup<GameEntity> _cameras;

      public CameraClampZSystem(GameContext context)
      {
         _cameras = context.GetGroup(GameMatcher
            .AllOf(
               GameMatcher.Camera,
               GameMatcher.WorldPosition
            ));
      }

      public void Execute()
      {
         foreach (GameEntity entity in _cameras)
         {
            var clamped = new Vector3(entity.WorldPosition.x, entity.WorldPosition.y, CameraConstants.DefaultZ);
            entity.ReplaceWorldPosition(clamped);
         }
      }
   }
}