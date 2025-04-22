using Code.Gameplay.Features.TargetCollection;
using Entitas;

namespace Code.Gameplay.Features.Enemy.Systems
{
   public sealed class EnemyDeathSystem : IExecuteSystem
   {
      private readonly IGroup<GameEntity> _enemies;

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
         foreach (GameEntity enemy in _enemies)
         {
            enemy.isMovementAvailable = false;
            enemy.isTurnedAlongDirection = false;
        
            enemy.RemoveTargetCollectionComponents();
        
            enemy.isDead = true;
            enemy.isProcessingDeath = true;
            
            /*if(enemy.hasEnemyAnimator)
               enemy.EnemyAnimator.PlayDied();

            enemy.ReplaceSelfDestructTimer(DeathAnimationTime);*/
         }
      }
   }
}