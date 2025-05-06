using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.GameOver
{
   public sealed class GameOverOnPlayerDeathSystem : ReactiveSystem<GameEntity>
   {
      public GameOverOnPlayerDeathSystem(GameContext context) : base(context)
      {
      }

      protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) =>
         context.CreateCollector(GameMatcher.AllOf(GameMatcher.Player, GameMatcher.Dead).Added());

      protected override bool Filter(GameEntity hero) => hero.isDead;

      protected override void Execute(List<GameEntity> heroes) =>
         GameOverSignalBus.NotifyGameOver();
   }
}