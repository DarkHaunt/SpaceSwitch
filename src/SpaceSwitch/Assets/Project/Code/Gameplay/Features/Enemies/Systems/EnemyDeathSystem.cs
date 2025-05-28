using System.Collections.Generic;
using Code.Gameplay.Common;
using Code.Gameplay.Features.TargetCollection;
using Entitas;

namespace Code.Gameplay.Features.Enemy.Systems
{
   public sealed class EnemyDeathSystem : IExecuteSystem
   {
      private readonly IGroup<GameEntity> _enemies;
      private readonly List<GameEntity> _buffer = new(16);

      public EnemyDeathSystem(GameContext context)
      {
         _enemies = context.GetGroup(GameMatcher
            .AllOf(
               GameMatcher.Enemy,
               GameMatcher.Dead,
               GameMatcher.ProcessingDeath));
      }

      public void Execute()
      {
         foreach (GameEntity enemy in _enemies.GetEntities(_buffer))
         {
            enemy.isMoving = false;
            enemy.isMovingSpline = false;
            enemy.isMovementAvailable = false;
            enemy.isTurnedAlongDirection = false;

            enemy.RemoveTargetCollectionComponents();
            enemy.RemoveAndDisableCollider();

            if (enemy.hasEnemyAnimator && enemy.hasColorType)
            {
               var animationTime = enemy.EnemyAnimator.PlayDeathParticle(enemy.ColorType);
               enemy.ReplaceSelfDestructTimer(animationTime);
            }
            
            if (enemy.hasEnemySoundPlayer)
               enemy.EnemySoundPlayer.PlayDeathSound();

            enemy.isProcessingDeath = false;
         }
      }
   }
}