using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Movement.Systems
{
   public sealed class ClampZPositionSystem : IExecuteSystem
   {
      private readonly IGroup<GameEntity> _entities;

      public ClampZPositionSystem(GameContext context)
      {
         _entities = context.GetGroup(GameMatcher
            .AllOf(
               GameMatcher.WorldPosition,
               GameMatcher.ClampedZ
            ));
      }

      public void Execute()
      {
         foreach (GameEntity entity in _entities)
         {
            var clamped = new Vector3(entity.WorldPosition.x, entity.WorldPosition.y, entity.ClampedZ);
            entity.ReplaceWorldPosition(clamped);
         }
      }
   }
}