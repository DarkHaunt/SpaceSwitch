using System.Collections.Generic;
using Code.Infrastructure.States.GameStates;
using Code.Infrastructure.States.StateMachine;
using Entitas;

namespace Code.Gameplay.Features.GameOver
{
   public sealed class GameOverOnPlayerDeathSystem : ReactiveSystem<GameEntity>
   {
      private readonly IGameStateMachine _stateMachine;

      public GameOverOnPlayerDeathSystem(GameContext context, IGameStateMachine stateMachine) : base(context)
      {
         _stateMachine = stateMachine;
      }

      protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) =>
         context.CreateCollector(GameMatcher.AllOf(GameMatcher.Player, GameMatcher.Dead).Added());

      protected override bool Filter(GameEntity hero) => hero.isDead;

      protected override void Execute(List<GameEntity> heroes)
      {
         _stateMachine.Enter<GameOverState>();
      }
   }
}