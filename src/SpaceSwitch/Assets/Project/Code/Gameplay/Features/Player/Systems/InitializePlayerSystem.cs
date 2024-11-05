using System.Collections.Generic;
using Entitas;

namespace Project.Code.Gameplay.Features.Player.Systems
{
   public class InitializePlayerSystem : IInitializeSystem
   {
      private readonly IGroup<GameEntity> _heroes;

      public InitializePlayerSystem(GameContext game)
      {
         _heroes = game.GetGroup(GameMatcher
            .AllOf
               (
                  GameMatcher.PlayerAnimator,
                  GameMatcher.Player,
                  GameMatcher.Speed
               )
            .NoneOf(GameMatcher.ProcessingAsyncSpawn));
      }
      
      public void Initialize()
      {
         foreach (GameEntity player in _heroes)
            player.PlayerAnimator.Init(player.Speed);
      }
   }
}