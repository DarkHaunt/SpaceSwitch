using System;
using Code.Gameplay.Score;
using VContainer.Unity;

namespace Code.Gameplay.UI
{
   public class GameUIController : IInitializable, IDisposable
   {
      private readonly GameView _view;
      private readonly ScoreService _scoreService;

      public GameUIController(GameView view, ScoreService scoreService)
      {
         _view = view;
         _scoreService = scoreService;
      }

      public void Initialize()
      {
         _scoreService.OnScoreUpdated += UpdateScore;
         UpdateScore();
      }

      public void Dispose() =>
         _scoreService.OnScoreUpdated -= UpdateScore;

      private void UpdateScore() =>
         _view.Score.text = $"Score - {_scoreService.Score:N0}";
   }
}