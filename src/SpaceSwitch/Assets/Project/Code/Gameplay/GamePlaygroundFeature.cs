using Code.Common.Destruct;
using Code.Gameplay.Features.ColorSwitch;
using Code.Gameplay.Features.Lifetime.Systems;
using Code.Gameplay.Features.Movement;
using Code.Gameplay.Features.Player;
using Code.Gameplay.Features.Shooting.Systems;
using Code.Gameplay.Features.TargetCollection;
using Code.Gameplay.Input;
using Code.Infrastructure.Systems;
using Code.Infrastructure.View;
using Project.Code.Gameplay.Features.Cameras;

namespace Code.Gameplay
{
  public class GamePlaygroundFeature : Feature
  {
    public GamePlaygroundFeature(ISystemFactory systems)
    {
      Add(systems.Create<InputFeature>());
      Add(systems.Create<BindViewFeature>());
      
      Add(systems.Create<PlayerFeature>());
      Add(systems.Create<CameraFeature>());
      
      Add(systems.Create<DeathFeature>());
      Add(systems.Create<MovementFeature>());
      Add(systems.Create<ShootingFeature>());
 
      Add(systems.Create<CollectTargetsFeature>());
      Add(systems.Create<ColorSwitchFeature>());
      
      Add(systems.Create<ProcessDestructedFeature>());
    }
  }
}