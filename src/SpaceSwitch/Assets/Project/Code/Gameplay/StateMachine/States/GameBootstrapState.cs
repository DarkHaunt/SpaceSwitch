using Code.Gameplay.Cameras.Provider;
using Code.Gameplay.Features.Player.Factories;
using Code.Gameplay.Features.Scrolling.Services;
using Code.Gameplay.Score;
using Code.Gameplay.StaticData;
using Code.Infrastructure.States.StateInfrastructure;
using Code.Infrastructure.States.StateMachine;
using Project.Code.Common.UI.LoadingCurtain;
using UnityEngine;

namespace Code.Gameplay.StateMachine.States
{
   public class GameBootstrapState : SimpleState
   {
      private readonly IStaticDataService _staticDataService;
      private readonly LevelPartsHandleService _levelService;
      private readonly IGameStateMachine _stateMachine;
      private readonly PlayerFactory _playerFactory;
      private readonly ScoreService _scoreService;
      private readonly ILoadingCurtain _curtain;
      private readonly ICameraProvider _cameraProvider;

      public GameBootstrapState(IGameStateMachine stateMachine, PlayerFactory playerFactory, ScoreService scoreService,
         ILoadingCurtain curtain, ICameraProvider cameraProvider, IStaticDataService staticDataService, LevelPartsHandleService levelService)
      {
         _stateMachine = stateMachine;
         _playerFactory = playerFactory;
         _scoreService = scoreService;
         _curtain = curtain;
         _cameraProvider = cameraProvider;
         _staticDataService = staticDataService;
         _levelService = levelService;
      }

      public override async void Enter()
      {
         _curtain.ShowImmediate();
         _scoreService.ClearCurrentScore();
         
         await _staticDataService.LoadAll();

         _cameraProvider.SetMainCamera(Camera.main);
         _playerFactory.CreateHero(Vector3.zero, _staticDataService.PlayerConfig);
         _levelService.Setup();

         _stateMachine.Enter<GameLoopState>();
      }
   }
}