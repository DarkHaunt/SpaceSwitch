using Entitas;

namespace Code.Gameplay.Features.Movement.Systems
{
   public class UpdateTransformRotationSystem : IExecuteSystem
   {
      private readonly IGroup<GameEntity> _movers;

      public UpdateTransformRotationSystem(GameContext game)
      {
         _movers = game.GetGroup(GameMatcher
            .AllOf(
               GameMatcher.WorldRotation,
               GameMatcher.Transform));
      }
    
      public void Execute()
      {
         foreach (GameEntity mover in _movers)
         {
            mover.Transform.rotation = mover.WorldRotation;
         }
      }
   }
}