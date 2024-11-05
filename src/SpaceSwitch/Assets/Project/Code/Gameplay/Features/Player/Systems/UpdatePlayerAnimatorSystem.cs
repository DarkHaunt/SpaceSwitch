using Entitas;

namespace Code.Gameplay.Features.Player.Systems
{
   public sealed class UpdatePlayerAnimatorSystem : IExecuteSystem
   {
      private readonly IGroup<GameEntity> _players;

      public UpdatePlayerAnimatorSystem(GameContext context)
      {
         _players = context.GetGroup(GameMatcher
            .AllOf(
               GameMatcher.PlayerAnimator,
               GameMatcher.Velocity
            ));
      }

      public void Execute()
      {
         foreach (GameEntity player in _players)
         {
            player.PlayerAnimator.UpdateViewRotationFromVelocity(player.Velocity);
         }
      }
   }
}