using Code.Gameplay.Features.ColorSwitch.Behaviors;
using Code.Infrastructure.View.Registrars;

namespace Code.Gameplay.Features.ColorSwitch.Registrars
{
   public class ColorSwitchAnimatorRegistrar : EntityComponentRegistrar
   {
      public ColorSwitchAnimator Animator;

      public override void RegisterComponents()
      {
         Entity
            .AddColorSwitchAnimator(Animator)
            ;
      }

      public override void UnregisterComponents()
      {
         if (Entity.hasColorSwitchAnimator)
            Entity.RemoveColorSwitchAnimator();
      }
   }
}