using Code.Gameplay.Features.Scrolling.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Scrolling
{
   public sealed class LevelBGMoveFeature : Feature
   {
      public LevelBGMoveFeature(ISystemFactory systems)
      {
         Add(systems.Create<HandleLevelPartsSwitchSystem>());
      }
   }
}