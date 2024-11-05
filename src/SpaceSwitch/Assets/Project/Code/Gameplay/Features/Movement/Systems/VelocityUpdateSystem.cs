using Entitas;

namespace Code.Gameplay.Features.Movement.Systems
{
   public sealed class VelocityUpdateSystem : IExecuteSystem
   {
      private readonly IGroup<GameEntity> _entities;

      public VelocityUpdateSystem(GameContext context)
      {
         _entities = context.GetGroup(GameMatcher
            .AllOf(
               GameMatcher.Speed,
               GameMatcher.Direction,
               GameMatcher.Velocity
            ));
      }

      public void Execute()
      {
         foreach (GameEntity entity in _entities)
         {
            entity.ReplaceVelocity(entity.Speed * entity.Direction);
         }
      }
   }
}