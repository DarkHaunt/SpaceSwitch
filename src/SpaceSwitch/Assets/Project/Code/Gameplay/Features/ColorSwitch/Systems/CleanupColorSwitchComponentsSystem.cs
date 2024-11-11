using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.ColorSwitch.Systems
{
   public sealed class CleanupColorSwitchComponentsSystem : ICleanupSystem
   {
      private readonly IGroup<GameEntity> _colorSwitchers;
      private readonly List<GameEntity> _buffer = new(32);

      public CleanupColorSwitchComponentsSystem(GameContext context)
      {
         _colorSwitchers = context.GetGroup(GameMatcher.AllOf(GameMatcher.ColorSwitchRequest));
      }

      public void Cleanup()
      {
         foreach (GameEntity colorSwitcher in _colorSwitchers.GetEntities(_buffer))
            colorSwitcher.RemoveColorSwitchRequest();
      }
   }
}