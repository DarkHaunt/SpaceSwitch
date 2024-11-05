using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Hero.Systems
{
  public class SetPlayerDirectionByInputSystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> _players;
    private readonly IGroup<InputEntity> _inputs;

    public SetPlayerDirectionByInputSystem(GameContext game, InputContext input)
    {
      _players = game.GetGroup(GameMatcher.Player);
      _inputs = input.GetGroup(InputMatcher.Input);
    }
    
    public void Execute()
    {
      foreach (InputEntity input in _inputs)
      foreach (GameEntity player in _players)
      {
        player.isMoving = input.hasAxisInput;

        if (input.hasAxisInput) 
          player.ReplaceDirection(input.AxisInput.normalized);
        else
          player.ReplaceDirection(Vector2.zero);
        
      }
    }
  }
}