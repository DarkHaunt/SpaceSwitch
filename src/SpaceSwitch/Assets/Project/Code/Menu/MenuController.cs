using System;
using Code.Infrastructure.Loading;
using Project.Code.Common.Infrastructure.SceneLoader;
using Project.Code.Common.UI.LoadingCurtain;
using Project.Code.Infrastructure.Save;
using UnityEngine;
using VContainer.Unity;

namespace Code.Menu
{
   public class MenuController : IInitializable, IDisposable
   {
      private readonly ILoadingCurtain _loadingCurtain;
      private readonly ISceneLoader _sceneLoader;
      
      private readonly MenuView _view;

      public MenuController(MenuView view, ILoadingCurtain loadingCurtain, ISceneLoader sceneLoader)
      {
         _loadingCurtain = loadingCurtain;
         _sceneLoader = sceneLoader;
         
         _view = view;
      }


      public void Initialize()
      {
         _view.StartButton.onClick.AddListener(StartGame);
         _view.QuitButton.onClick.AddListener(QuitGame);

         LoadLastScore();
      }

      public void Dispose()
      {
         _view.StartButton.onClick.RemoveListener(StartGame);
         _view.QuitButton.onClick.RemoveListener(QuitGame);
      }

      private void LoadLastScore()
      {
         var lastScore = PlayerPrefs.GetInt(PrefsKeys.ScoreKey, 0);
         _view.ScoreField.text = $"Highest Score - {lastScore.ToString()}";
      }

      private async void StartGame()
      {
         Dispose();

         await _loadingCurtain.Show();
         await _sceneLoader.Load(SceneName.Game);
      }

      private void QuitGame()
      {
#if UNITY_EDITOR
         UnityEditor.EditorApplication.isPlaying = false;
#else
         UnityEngine.Application.Quit();
#endif
      }
   }
}