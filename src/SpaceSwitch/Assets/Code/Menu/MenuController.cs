using System;
using Code.Infrastructure.Loading;
using Code.Infrastructure.States.GameStates;
using Code.Infrastructure.States.StateMachine;
using Project.Code.Common.Infrastructure.SceneLoader;
using Project.Code.Common.UI.LoadingCurtain;
using VContainer.Unity;

namespace Code.Menu
{
   public class MenuController : IInitializable, IDisposable
   {
      private readonly MenuView _view;
      private readonly IGameStateMachine _stateMachine;
      private readonly ILoadingCurtain _loadingCurtain;
      private readonly ISceneLoader _sceneLoader;

      public MenuController(MenuView view, IGameStateMachine stateMachine, ILoadingCurtain loadingCurtain, ISceneLoader sceneLoader)
      {
         _loadingCurtain = loadingCurtain;
         _stateMachine = stateMachine;
         _sceneLoader = sceneLoader;
         _view = view;
      }


      public void Initialize()
      {
         _view.StartButton.onClick.AddListener(StartGame);
         _view.QuitButton.onClick.AddListener(QuitGame);
      }

      public void Dispose()
      {
         _view.StartButton.onClick.RemoveListener(StartGame);
         _view.QuitButton.onClick.RemoveListener(QuitGame);
      }

      private async void StartGame()
      {
         Dispose();

         await _loadingCurtain.Show();
         await _sceneLoader.Load(SceneName.Game);
         
         _stateMachine.Enter<GameLoopState>();
      }

      private void QuitGame()
      {
#if UNITY_EDITOR
         UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
      }
   }
}