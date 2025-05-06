using System.Collections.Generic;
using Code.Gameplay.Common;
using Entitas;

namespace Code.Gameplay.Features.Player.Systems
{
   public sealed class PlayerDeathSystem : IExecuteSystem
   {
      private readonly IGroup<GameEntity> _players;
      private readonly List<GameEntity> _buffer = new(1);

      public PlayerDeathSystem(GameContext game)
      {
         _players = game.GetGroup(GameMatcher
            .AllOf(
               GameMatcher.Player,
               GameMatcher.Dead,
               GameMatcher.ProcessingDeath));
      }

      public void Execute()
      {
         foreach (GameEntity player in _players.GetEntities(_buffer))
         {
            player.isMovementAvailable = false;
            player.isShooter = false;
            
            if (player.hasPlayerAnimator)
            {
               var animationTime = player.PlayerAnimator.PlayDeathParticle();
               player.ReplaceSelfDestructTimer(animationTime);
            }
            
            player.RemoveAndDisableCollider();
            player.isProcessingDeath = false;
         }
      }
   }
}