using Code.Gameplay.Features.ColorSwitch.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.ColorSwitch
{
   public sealed class ColorSwitchFeature : Feature
   {
      public ColorSwitchFeature(ISystemFactory systems)
      {
         Add(systems.Create<ColorSetupSystem>());
         Add(systems.Create<ColorSwitchSystem>());
         
         Add(systems.Create<CleanupColorSwitchComponentsSystem>());
      }
   }
}