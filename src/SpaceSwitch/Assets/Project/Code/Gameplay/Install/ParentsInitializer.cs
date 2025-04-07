using Code.Gameplay.Features.Enemy;
using Code.Gameplay.Windows;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Code.Infrastructure.Installers
{
  public class ParentsInitializer : MonoBehaviour, IInitializable
  {
    private IWindowFactory _windowFactory;
    
    public RectTransform UIRoot;
    public Transform ProjectilesRoot;
    public Transform EnemiesRoot;

    [Inject]
    private void Construct(IWindowFactory windowFactory, EnemyFactory enemyFactory) =>
      _windowFactory = windowFactory;

    public void Initialize() => 
      _windowFactory.SetUIRoot(UIRoot);
  }
}