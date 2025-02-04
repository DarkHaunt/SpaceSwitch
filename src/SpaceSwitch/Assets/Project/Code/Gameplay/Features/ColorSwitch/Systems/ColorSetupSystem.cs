using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.ColorSwitch.Systems
{
   public sealed class ColorSetupSystem : ReactiveSystem<GameEntity>
   {
      public ColorSetupSystem(GameContext context) : base(context)
      {
      }

      protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) =>
         context.CreateCollector(GameMatcher.AllOf
         (
            GameMatcher.ColorType,
            GameMatcher.ColorSwitchAnimator
         ).Added());

      protected override bool Filter(GameEntity entity) => entity.hasColorType && entity.hasColorSwitchAnimator;

      protected override void Execute(List<GameEntity> entities)
      {
         foreach (GameEntity entity in entities)
            entity.ColorSwitchAnimator.SetColor(entity.ColorType);
      }
   }
}