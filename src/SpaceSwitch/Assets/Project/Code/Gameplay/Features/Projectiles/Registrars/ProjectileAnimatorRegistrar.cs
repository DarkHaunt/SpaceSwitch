using Code.Gameplay.Features.Projectiles.Behaviors;
using Code.Infrastructure.View.Registrars;
using UnityEngine;

namespace Code.Gameplay.Features.Projectiles.Registrars
{
   public class ProjectileAnimatorRegistrar : EntityComponentRegistrar
   {
      public ProjectileAnimator ProjectileAnimator;

      public override void RegisterComponents()
      {
         Entity
            .AddProjectileAnimator(ProjectileAnimator)
            ;
      }

      public override void UnregisterComponents()
      {
         if (Entity.hasProjectileAnimator)
            Entity.RemoveProjectileAnimator();
      }
   }
}