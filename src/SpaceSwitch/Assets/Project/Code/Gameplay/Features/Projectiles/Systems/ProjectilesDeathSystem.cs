using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Projectiles.Systems
{
   public sealed class ProjectilesDeathSystem : IExecuteSystem
   {
      private readonly IGroup<GameEntity> _projectilesGroup;
      private readonly List<GameEntity> _buffer = new(16);

      public ProjectilesDeathSystem(GameContext context)
      {
         _projectilesGroup = context.GetGroup(GameMatcher
            .AllOf(
               GameMatcher.Projectile,
               GameMatcher.ProcessingDeath,
               GameMatcher.Dead,
               GameMatcher.Collider,
               GameMatcher.ColorType
            ));
      }

      public void Execute()
      {
         foreach (GameEntity projectile in _projectilesGroup.GetEntities(_buffer))
         {
            if (projectile.hasProjectileAnimator)
            {
               var deathTime = projectile.ProjectileAnimator.PlayDeathParticle(projectile.ColorType);
               projectile.ReplaceSelfDestructTimer(deathTime);
            }
            
            projectile.isProcessingDeath = false;
            
            projectile.isMovementAvailable = false;
            projectile.isTurnedAlongDirection = false;
 
            projectile.RemoveCollider();
         }
      }
   }
}