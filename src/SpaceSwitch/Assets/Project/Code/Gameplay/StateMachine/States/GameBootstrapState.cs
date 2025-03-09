using Code.Gameplay.Cameras.Provider;
using Code.Gameplay.Features.Player.Factories;
using Code.Gameplay.Features.Scrolling.Services;
using Code.Gameplay.StaticData;
using Code.Infrastructure.States.StateInfrastructure;
using Code.Infrastructure.States.StateMachine;
using Project.Code.Common.UI.LoadingCurtain;
using Project.Code.Gameplay.Features.Cameras.Factories;
using UnityEngine;

namespace Code.Gameplay.StateMachine.States
{
   public class GameBootstrapState : SimpleState
   {
      private readonly IStaticDataService _staticDataService;
      private readonly LevelPartsHandleService _levelService;
      private readonly IGameStateMachine _stateMachine;
      private readonly IPlayerFactory _playerFactory;
      private readonly ILoadingCurtain _curtain;
      private readonly ICameraProvider _cameraProvider;

      public GameBootstrapState(IGameStateMachine stateMachine, IPlayerFactory playerFactory, CameraFactory cameraFactory,
         ILoadingCurtain curtain, ICameraProvider cameraProvider, IStaticDataService staticDataService, LevelPartsHandleService levelService)
      {
         _stateMachine = stateMachine;
         _playerFactory = playerFactory;
         _curtain = curtain;
         _cameraProvider = cameraProvider;
         _staticDataService = staticDataService;
         _levelService = levelService;
      }

      public override async void Enter()
      {
         _curtain.ShowImmediate();
         await _staticDataService.LoadAll();

         _cameraProvider.SetMainCamera(Camera.main);
         _playerFactory.CreateHero(Vector3.zero, _staticDataService.PlayerConfig);
         _levelService.Setup();

         _stateMachine.Enter<GameLoopState>();
      }
   }
}