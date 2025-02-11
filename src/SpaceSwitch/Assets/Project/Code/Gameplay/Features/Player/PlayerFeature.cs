using Code.Gameplay.Features.Hero.Systems;
using Code.Gameplay.Features.Player.Systems;
using Code.Infrastructure.Systems;
using Project.Code.Gameplay.Features.Player.Systems;

namespace Code.Gameplay.Features.Player
{
   public sealed class PlayerFeature : Feature
   {
      public PlayerFeature(ISystemFactory systems)
      {
         //Add(systems.Create<InitializePlayerSystem>());
         Add(systems.Create<PlayerAnimatorInitSystem>());
         
         Add(systems.Create<SetPlayerDirectionByInputSystem>());
         Add(systems.Create<ClampMovementWithCameraBoundsSystem>());
         
         Add(systems.Create<PlayerColorSwitchByInputSystem>());
         Add(systems.Create<PlayerShootByInputSystem>());
         
         Add(systems.Create<UpdatePlayerAnimatorSystem>());
      }
   }
}