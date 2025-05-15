using Code.Gameplay.Features.GameOver;
using Code.Gameplay.Score;
using Code.Gameplay.Windows;
using Code.Infrastructure.Loading;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using Project.Code.Common.Infrastructure.SceneLoader;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace Code.Gameplay.GameOver.UI
{
   public class GameOverWindow : BaseWindow
   {
      public Button ReturnHomeButton;
      public Button RestartLevelButton;

      public TextMeshProUGUI ScoreText;
      public CanvasGroup Group;
      public GameObject Panel;

      private IWindowService _windowService;
      private ScoreService _scoreService;
      private ISceneLoader _sceneLoader;

      [Inject]
      private void Construct(ISceneLoader sceneLoader, ScoreService scoreService, IWindowService windowService)
      {
         Id = WindowId.GameOverWindow;

         _sceneLoader = sceneLoader;
         _scoreService = scoreService;
         _windowService = windowService;

         AnimationPrewarm();
      }

      private void AnimationPrewarm()
      {
         Group.alpha = 0;
         Panel.SetActive(false);
         Panel.transform.localScale = Vector3.zero;
      }

      protected override void Initialize()
      {
         ScoreText.text = $"Your score: {_scoreService.Score}";

         ReturnHomeButton.onClick.AddListener(ReturnHome);
         RestartLevelButton.onClick.AddListener(RestartLevel);

         AnimateAppear();
      }

      private async void AnimateAppear()
      {
         await Group.DOFade(1, 0.5f)
            .ToUniTask();

         Panel.SetActive(true);
         await Panel.transform.DOScale(1, 0.5f)
            .SetEase(Ease.OutBack)
            .ToUniTask();
      }

      private void ReturnHome()
      {
         GameOverSignalBus.NotifyGameplaySceneUnload();
         _sceneLoader.LoadWithCurtain(SceneName.Menu);
         _windowService.Close(Id);
      }

      private void RestartLevel()
      {
         GameOverSignalBus.NotifyGameplaySceneUnload();
         _sceneLoader.LoadWithCurtain(SceneName.Game, force: true);
         _windowService.Close(Id);
      }
   }
}