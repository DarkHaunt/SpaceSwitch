using Code.Gameplay.Score;
using Code.Gameplay.Windows;
using Code.Infrastructure.Loading;
using Code.Infrastructure.States.GameStates;
using Project.Code.Common.Infrastructure.SceneLoader;
using TMPro;
using UnityEngine.UI;
using VContainer;

namespace Code.Gameplay.GameOver.UI
{
  public class GameOverWindow : BaseWindow
  {
    public Button ReturnHomeButton;
    public Button RestartLevelButton;
    
    public TextMeshProUGUI ScoreText;

    private IWindowService _windowService;
    private ScoreService _scoreService;
    private ISceneLoader _sceneLoader;

    [Inject]
    private void Construct(ISceneLoader sceneLoader, ScoreService scoreService, IWindowService windowService)
    {
      _sceneLoader = sceneLoader;
      _scoreService = scoreService;
      Id = WindowId.GameOverWindow;

      _windowService = windowService;
    }

    protected override void Initialize()
    {
      ScoreText.text = $"Your score: {_scoreService.Score}";
      
      ReturnHomeButton.onClick.AddListener(ReturnHome);
      RestartLevelButton.onClick.AddListener(RestartLevel);
    }

    private void ReturnHome()
    {
      _sceneLoader.Load(SceneName.Menu);
      _windowService.Close(Id);
    }

    private void RestartLevel()
    {
      _sceneLoader.Load(SceneName.Game, force: true);
      _windowService.Close(Id);
    }
  }
}