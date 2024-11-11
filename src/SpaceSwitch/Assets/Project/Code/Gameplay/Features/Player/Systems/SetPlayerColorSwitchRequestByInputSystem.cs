using Code.Gameplay.Features.ColorSwitch.StaticData;
using Entitas;

namespace Project.Code.Gameplay.Features.Player.Systems
{
   public sealed class SetPlayerColorSwitchRequestByInputSystem : IExecuteSystem
   {
      private readonly IGroup<GameEntity> _players;
      private readonly IGroup<InputEntity> _inputs;

      public SetPlayerColorSwitchRequestByInputSystem(GameContext gameContext, InputContext inputContext)
      {
         _inputs = inputContext.GetGroup(InputMatcher.Input);
         _players = gameContext.GetGroup(GameMatcher
            .AllOf(
               GameMatcher.Player,
               GameMatcher.ColorType
            ));
      }

      public void Execute()
      {
         foreach (InputEntity input in _inputs)
         foreach (GameEntity player in _players)
         {
            ColorType colorType = ColorSwitchProvider.NextColorAfter(player.ColorType);

            if (input.isSwitchRequested)
               player.AddColorSwitchRequest(colorType);
         }
      }
   }
}