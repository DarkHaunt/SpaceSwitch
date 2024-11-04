using Code.Infrastructure.States.StateInfrastructure;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.StateMachine.States
{
   public class GameLoopState : EndOfFrameExitState
   {
      private readonly ISystemFactory _systems;
      private readonly GameContext _gameContext;
    
      private BattleFeature _battleFeature;

      public GameLoopState(ISystemFactory systems, GameContext gameContext)
      {
         _gameContext = gameContext;
         _systems = systems;
      }
    
      public override void Enter()
      {
         _battleFeature = _systems.Create<BattleFeature>();
         _battleFeature.Initialize();
      }

      protected override void OnUpdate()
      {
         _battleFeature.Execute();
         _battleFeature.Cleanup();
      }

      protected override void ExitOnEndOfFrame()
      {
         _battleFeature.DeactivateReactiveSystems();
         _battleFeature.ClearReactiveSystems();

         DestructEntities();
      
         _battleFeature.Cleanup();
         _battleFeature.TearDown();
         _battleFeature = null;
      }

      private void DestructEntities()
      {
         foreach (GameEntity entity in _gameContext.GetEntities()) 
            entity.isDestructed = true;
      }
   }
}