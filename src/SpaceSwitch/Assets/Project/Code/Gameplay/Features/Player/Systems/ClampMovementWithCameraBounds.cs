using Code.Gameplay.Cameras.Provider;
using Code.Gameplay.Common;
using Entitas;
using UnityEngine;

namespace Project.Code.Gameplay.Features.Player.Systems
{
   public sealed class ClampMovementWithCameraBoundsSystem : IExecuteSystem
   {
      private readonly ICameraProvider _cameraProvider;
      private readonly IGroup<GameEntity> _players;

      public ClampMovementWithCameraBoundsSystem(GameContext context, ICameraProvider cameraProvider)
      {
         _cameraProvider = cameraProvider;
         _players = context.GetGroup(GameMatcher
            .AllOf(
               GameMatcher.Player,
               GameMatcher.WorldPosition
            ));
      }

      public void Execute()
      {
         foreach (GameEntity player in _players)
         {
            Vector3 playerPosition = player.WorldPosition;
            
            Vector2 leftBottomBoundPosition = _cameraProvider.WorldLeftBottomBoundPosition + GameplayConstants.CameraBoundsOffset;
            Vector2 rightTopBoundPosition = _cameraProvider.WorldRightTopBoundPosition - GameplayConstants.CameraBoundsOffset;
            
            playerPosition.x = Mathf.Clamp(playerPosition.x, leftBottomBoundPosition.x, rightTopBoundPosition.x);
            playerPosition.y = Mathf.Clamp(playerPosition.y, leftBottomBoundPosition.y, rightTopBoundPosition.y);
            
            player.ReplaceWorldPosition(playerPosition);
         }
      }
   }
}