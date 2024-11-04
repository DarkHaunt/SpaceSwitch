using Code.Gameplay.Features.Player.Behaviors;
using Code.Infrastructure.View.Registrars;
using UnityEngine;

namespace Code.Gameplay.Features.Player.Registrars
{
   public class PlayerAnimatorRegistrar : EntityComponentRegistrar
   {
      public PlayerAnimator PlayerAnimator;

      public override void RegisterComponents()
      {
         Entity
            .AddPlayerAnimator(PlayerAnimator)
            ;
      }

      public override void UnregisterComponents()
      {
         if (Entity.hasPlayerAnimator)
            Entity.RemovePlayerAnimator();
      }
   }
}