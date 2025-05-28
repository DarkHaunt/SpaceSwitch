using Code.Gameplay.Features.Enemy.Behaviors;
using Code.Infrastructure.View.Registrars;

namespace Code.Gameplay.Features.Enemy.Registrars
{
   public class EnemySoundPlayerRegistrar : EntityComponentRegistrar
   {
      public EnemySoundPlayer EnemySoundPlayer;

      public override void RegisterComponents()
      {
         Entity
            .AddEnemySoundPlayer(EnemySoundPlayer)
            ;
      }

      public override void UnregisterComponents()
      {
         if (Entity.hasEnemySoundPlayer)
            Entity.RemoveEnemySoundPlayer();
      }
   }
}