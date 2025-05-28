using Code.Gameplay.Features.Projectiles.Behaviors;
using Code.Infrastructure.View.Registrars;

namespace Code.Gameplay.Features.Projectiles.Registrars
{
   public class ProjectileSoundPlayerRegistrar : EntityComponentRegistrar
   {
      public ProjectileSoundPlayer ProjectileSoundPlayer;

      public override void RegisterComponents()
      {
         Entity
            .AddProjectileSoundPlayer(ProjectileSoundPlayer)
            ;
      }
      
      public override void UnregisterComponents()
      {
         if (Entity.hasProjectileSoundPlayer)
            Entity.RemoveProjectileSoundPlayer();
      }
   }
}