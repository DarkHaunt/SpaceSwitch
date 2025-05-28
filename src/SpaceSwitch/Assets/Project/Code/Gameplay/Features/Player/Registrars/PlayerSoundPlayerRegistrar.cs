using Code.Gameplay.Features.Player.Behaviors;
using Code.Infrastructure.View.Registrars;

namespace Code.Gameplay.Features.Player.Registrars
{
   public class PlayerSoundPlayerRegistrar : EntityComponentRegistrar
   {
      public PlayerSoundPlayer PlayerSoundPlayer;

      public override void RegisterComponents()
      {
         Entity
            .AddPlayerSoundPlayer(PlayerSoundPlayer)
            ;
      }
      
      public override void UnregisterComponents()
      {
         if (Entity.hasPlayerSoundPlayer)
            Entity.RemovePlayerSoundPlayer();
      }
   }
}