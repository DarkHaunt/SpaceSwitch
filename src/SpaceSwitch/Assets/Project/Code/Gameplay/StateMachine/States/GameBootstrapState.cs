using Code.Gameplay.Cameras.Provider;
using Code.Gameplay.Features.Player.Factories;
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
      private readonly IGameStateMachine _stateMachine;
      private readonly IPlayerFactory _playerFactory;
      private readonly ILoadingCurtain _curtain;
      private readonly ICameraProvider _cameraProvider;

      public GameBootstrapState(IGameStateMachine stateMachine, IPlayerFactory playerFactory,
         ILoadingCurtain curtain, ICameraProvider cameraProvider, IStaticDataService staticDataService)
      {
         _stateMachine = stateMachine;
         _playerFactory = playerFactory;
         _curtain = curtain;
         _cameraProvider = cameraProvider;
         _staticDataService = staticDataService;
      }

      public override async void Enter()
      {
         _curtain.HideImmediate();

         _playerFactory.CreateHero(Vector3.zero);

         _cameraProvider.SetMainCamera(Camera.main);

         await _staticDataService.LoadAll();
         await _curtain.Hide();

         _stateMachine.Enter<GameLoopState>();
      }
   }
}