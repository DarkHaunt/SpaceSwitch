using Code.Gameplay.Features.Enemy.Services;
using Code.Infrastructure.States.StateInfrastructure;
using Code.Infrastructure.Systems;
using Cysharp.Threading.Tasks;
using Project.Code.Common.UI.LoadingCurtain;

namespace Code.Gameplay.StateMachine.States
{
   public class GameLoopState : EndOfFrameExitState
   {
      private readonly ISystemFactory _systems;
      private readonly GameContext _gameContext;
      private readonly EnemySpawnService _spawnService;
      private readonly ILoadingCurtain _curtain;

      private GamePlaygroundFeature _gamePlaygroundFeature;

      public GameLoopState(ISystemFactory systems, GameContext gameContext, EnemySpawnService spawnService, ILoadingCurtain curtain)
      {
         _gameContext = gameContext;
         _spawnService = spawnService;
         _curtain = curtain;
         _systems = systems;
      }
    
      public override void Enter()
      {
         _gamePlaygroundFeature = _systems.Create<GamePlaygroundFeature>();
         _gamePlaygroundFeature.Initialize();

         _spawnService.StartEnemySpawning();
         _curtain.Hide().Forget();
      }

      protected override void OnUpdate()
      {
         _gamePlaygroundFeature.Execute();
         _gamePlaygroundFeature.Cleanup();
      }

      protected override void ExitOnEndOfFrame()
      {
         _gamePlaygroundFeature.DeactivateReactiveSystems();
         _gamePlaygroundFeature.ClearReactiveSystems();

         DestructEntities();
      
         _gamePlaygroundFeature.Cleanup();
         _gamePlaygroundFeature.TearDown();
         _gamePlaygroundFeature = null;
      }

      private void DestructEntities()
      {
         foreach (GameEntity entity in _gameContext.GetEntities()) 
            entity.isDestructed = true;
      }
   }
}