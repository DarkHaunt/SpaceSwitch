using Code.Gameplay.Score;
using Code.Gameplay.Windows;
using Code.Infrastructure.States.StateInfrastructure;
using UnityEngine;

namespace Code.Infrastructure.States.GameStates
{
  public class GameOverState : SimpleState
  {
    private readonly IWindowService _windowService;
    private readonly ScoreService _scoreService;

    public GameOverState(IWindowService windowService, ScoreService scoreService)
    {
      _windowService = windowService;
      _scoreService = scoreService;
    }
    
    public override void Enter()
    {
      Debug.Log($"<color=red> Game Over</color>");
      _windowService.Open(WindowId.GameOverWindow);
      _scoreService.CheckScoreSave();
    }
  }
}