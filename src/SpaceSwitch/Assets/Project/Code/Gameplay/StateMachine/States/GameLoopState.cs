using Code.Gameplay.Features.Enemy.Services;
using Code.Gameplay.Features.GameOver;
using Code.Gameplay.Score;
using Code.Gameplay.Windows;
using Code.Infrastructure.States.StateInfrastructure;
using Code.Infrastructure.Systems;
using Cysharp.Threading.Tasks;
using Project.Code.Common.UI.LoadingCurtain;
using UnityEngine;

namespace Code.Gameplay.StateMachine.States
{
   public class GameLoopState : EndOfFrameExitState
   {
      private readonly ISystemFactory _systems;
      private readonly InputContext _inputContext;
      private readonly GameContext _gameContext;
      
      private readonly EnemySpawnService _spawnService;
      private readonly ILoadingCurtain _curtain;
      private readonly IWindowService _windowService;
      private readonly ScoreService _scoreService;

      private GamePlaygroundFeature _gamePlaygroundFeature;
      private bool _isGameLoopActive = true;

      public GameLoopState(ISystemFactory systems, InputContext inputContext, GameContext gameContext, EnemySpawnService spawnService, 
         ILoadingCurtain curtain, IWindowService windowService, ScoreService scoreService)
      {
         _gameContext = gameContext;
         _spawnService = spawnService;
         _curtain = curtain;
         _windowService = windowService;
         _scoreService = scoreService;
         _systems = systems;
         _inputContext = inputContext;
      }
    
      public override void Enter()
      {
         _gamePlaygroundFeature = _systems.Create<GamePlaygroundFeature>();
         _gamePlaygroundFeature.Initialize();

         GameOverSignalBus.OnGameOver += GameOver;
         GameOverSignalBus.OnGameplaySceneUnloaded += GameplaySceneUnloaded;
         
         _spawnService.StartEnemySpawning();
         _curtain.Hide().Forget();
         
         _isGameLoopActive = true;
      }

      protected override void OnUpdate()
      {
         if (!_isGameLoopActive) return;
         
         _gamePlaygroundFeature.Execute();
         _gamePlaygroundFeature.Cleanup();
      }

      protected override void ExitOnEndOfFrame()
      {
         _scoreService.CheckScoreSave();
         
         _isGameLoopActive = false;
         
         _gamePlaygroundFeature.DeactivateReactiveSystems();
         _gamePlaygroundFeature.ClearReactiveSystems();

         DestructEntities();
      
         _gamePlaygroundFeature.Cleanup();
         _gamePlaygroundFeature.TearDown();
         _gamePlaygroundFeature = null;
      }

      private void GameplaySceneUnloaded()
      {
         GameOverSignalBus.OnGameOver -= GameOver;
         GameOverSignalBus.OnGameplaySceneUnloaded -= GameplaySceneUnloaded;

         ExitOnEndOfFrame();
      }

      private void GameOver()
      {
         _spawnService.StopEnemySpawning();
         _scoreService.CheckScoreSave();
         _windowService.Open(WindowId.GameOverWindow);
      }

      private void DestructEntities()
      {
         foreach (GameEntity entity in _gameContext.GetEntities()) 
            entity.isDestructed = true; 
         
         foreach (InputEntity entity in _inputContext.GetEntities())
            entity.isDestructed = true;
      }
   }
}