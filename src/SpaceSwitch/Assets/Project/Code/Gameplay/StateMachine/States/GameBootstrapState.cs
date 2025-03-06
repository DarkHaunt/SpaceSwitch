using Code.Gameplay.Cameras.Provider;
using Code.Gameplay.Features.Player.Factories;
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
      private readonly IGameStateMachine _stateMachine;
      private readonly IPlayerFactory _playerFactory;
      private readonly CameraFactory _cameraFactory;
      private readonly ILoadingCurtain _curtain;
      private readonly ICameraProvider _cameraProvider;

      public GameBootstrapState(IGameStateMachine stateMachine, IPlayerFactory playerFactory, CameraFactory cameraFactory,
         ILoadingCurtain curtain, ICameraProvider cameraProvider, IStaticDataService staticDataService)
      {
         _stateMachine = stateMachine;
         _playerFactory = playerFactory;
         _cameraFactory = cameraFactory;
         _curtain = curtain;
         _cameraProvider = cameraProvider;
         _staticDataService = staticDataService;
      }

      public override async void Enter()
      {
         _curtain.ShowImmediate();
         await _staticDataService.LoadAll();

         _cameraProvider.SetMainCamera(Camera.main);
         _cameraFactory.CreateCamera(_staticDataService.CameraConfig);
         _playerFactory.CreateHero(Vector3.zero, _staticDataService.PlayerConfig);

         _stateMachine.Enter<GameLoopState>();
      }
   }
}