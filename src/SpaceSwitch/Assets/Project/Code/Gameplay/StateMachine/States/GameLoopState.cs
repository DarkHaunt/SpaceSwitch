using Code.Infrastructure.States.StateInfrastructure;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.StateMachine.States
{
   public class GameLoopState : EndOfFrameExitState
   {
      private readonly ISystemFactory _systems;
      private readonly GameContext _gameContext;
    
      private GamePlaygroundFeature _gamePlaygroundFeature;

      public GameLoopState(ISystemFactory systems, GameContext gameContext)
      {
         _gameContext = gameContext;
         _systems = systems;
      }
    
      public override void Enter()
      {
         _gamePlaygroundFeature = _systems.Create<GamePlaygroundFeature>();
         _gamePlaygroundFeature.Initialize();
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