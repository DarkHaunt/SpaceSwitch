using System;
using Code.Gameplay.Common.Time;
using Code.Infrastructure.Loading;
using Cysharp.Threading.Tasks;
using Project.Code.Common.Infrastructure.SceneLoader;
using VContainer.Unity;

namespace Project.Code.Pause
{
   public class PauseService : IInitializable, IDisposable
   {
      private readonly ITimeService _time;
      private readonly PauseView _view;
      private readonly ISceneLoader _sceneLoader;

      private bool _isPaused;

      public PauseService(ITimeService time, PauseView view, ISceneLoader sceneLoader)
      {
         _time = time;
         _view = view;
         _sceneLoader = sceneLoader;
      }


      public void Initialize()
      {
         _view.PauseButton.onClick.AddListener(ChangePauseState);
         
         _view.RestartButton.onClick.AddListener(ReloadScene);
         _view.MainMenuButton.onClick.AddListener(GoToMenu);
         _view.ResumeButton.onClick.AddListener(ResumeGame);

         HidePanel();
      }

      public void Dispose()
      {
         if (_isPaused)
            _time.StartTime();
         
         _view.PauseButton.onClick.RemoveListener(ChangePauseState);
         
         _view.RestartButton.onClick.RemoveListener(ReloadScene);
         _view.MainMenuButton.onClick.RemoveListener(GoToMenu);
         _view.ResumeButton.onClick.RemoveListener(ResumeGame);
      }

      private void ChangePauseState()
      {
         _isPaused = !_isPaused;

         if (_isPaused)
            _time.StopTime();
         else
            _time.StartTime();
         
         _view.OpenedPanel.SetActive(_isPaused);
      }

      private void HidePanel() =>
         _view.OpenedPanel.SetActive(false);

      private void ResumeGame()
      {
         _time.StartTime();
         HidePanel();
      }

      private void GoToMenu()
      {
         ResumeGame();
         _sceneLoader.Load(SceneName.Menu, force: true).Forget();
      }

      private void ReloadScene()
      {
         ResumeGame();
         _sceneLoader.Load(SceneName.Game, force: true).Forget();
      }
   }
}