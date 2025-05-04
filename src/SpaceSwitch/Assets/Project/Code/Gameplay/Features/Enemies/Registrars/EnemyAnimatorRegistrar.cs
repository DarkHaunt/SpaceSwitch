using Code.Gameplay.Features.Enemy.Behaviors;
using Code.Infrastructure.View.Registrars;
using UnityEngine;

namespace Code.Gameplay.Features.Enemy.Registrars
{
   public class EnemyAnimatorRegistrar : EntityComponentRegistrar
   {
      public EnemyAnimator EnemyAnimator;

      public override void RegisterComponents()
      {
         Entity
            .AddEnemyAnimator(EnemyAnimator)
            ;
      }

      public override void UnregisterComponents()
      {
         if (Entity.hasEnemyAnimator)
            Entity.RemoveEnemyAnimator();
      }
   }
}