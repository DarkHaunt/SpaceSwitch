using Code.Gameplay.StaticData;
using Code.Infrastructure.Loading;
using Code.Infrastructure.States.StateInfrastructure;
using Code.Infrastructure.States.StateMachine;
using Project.Code.Common.Infrastructure.SceneLoader;
using Project.Code.Common.UI.LoadingCurtain;

namespace Code.Infrastructure.States.GameStates
{
  public class BootstrapState : SimpleState
  {
    private readonly IGameStateMachine _stateMachine;
    private readonly IStaticDataService _staticDataService;
    private readonly ILoadingCurtain _loadingCurtain;
    private readonly ISceneLoader _sceneLoader;

    public BootstrapState(IGameStateMachine stateMachine, IStaticDataService staticDataService, ISceneLoader sceneLoader, 
      ILoadingCurtain loadingCurtain)
    {
      _stateMachine = stateMachine;
      _staticDataService = staticDataService;
      _loadingCurtain = loadingCurtain;
      _sceneLoader = sceneLoader;
    }
    
    public override async void Enter()
    {
      _staticDataService.LoadAll();
      _loadingCurtain.HideImmediate();
      
      await _sceneLoader.Load(SceneName.Menu);
      
      _stateMachine.Enter<MenuLoopState>();
    }
  }
}