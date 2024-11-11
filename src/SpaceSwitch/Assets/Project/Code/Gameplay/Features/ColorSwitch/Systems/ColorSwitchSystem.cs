using Entitas;

namespace Code.Gameplay.Features.ColorSwitch.Systems
{
   public sealed class ColorSwitchSystem : IExecuteSystem
   {
      private readonly IGroup<GameEntity> _colorSwitchers;

      public ColorSwitchSystem(GameContext context)
      {
         _colorSwitchers = context.GetGroup(GameMatcher
            .AllOf(
               GameMatcher.ColorType,
               GameMatcher.ColorSwitchRequest
            ));
      }

      public void Execute()
      {
         foreach (GameEntity colorSwitcher in _colorSwitchers)
         {
             colorSwitcher.ReplaceColorType(colorSwitcher.ColorSwitchRequest);
             
             if(colorSwitcher.hasColorSwitchAnimator)
                colorSwitcher.ColorSwitchAnimator.SetColor(colorSwitcher.ColorSwitchRequest);
         }
      }
   }
}