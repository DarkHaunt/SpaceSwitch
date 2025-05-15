using Code.Common.Destruct;
using Code.Gameplay.Features.ColorSwitch;
using Code.Gameplay.Features.EffectApplication;
using Code.Gameplay.Features.Effects;
using Code.Gameplay.Features.Enemy;
using Code.Gameplay.Features.EnemyLifetime;
using Code.Gameplay.Features.GameOver;
using Code.Gameplay.Features.Lifetime.Systems;
using Code.Gameplay.Features.Movement;
using Code.Gameplay.Features.Player;
using Code.Gameplay.Features.Projectiles;
using Code.Gameplay.Features.Scrolling;
using Code.Gameplay.Features.Shooting.Systems;
using Code.Gameplay.Features.Splines;
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
      
      Add(systems.Create<EnemyLifetimeFeature>());
      Add(systems.Create<EnemyFeature>());
      
      Add(systems.Create<CollectTargetsFeature>());
      Add(systems.Create<ColorSwitchFeature>());
      
      Add(systems.Create<ShootingFeature>());
      Add(systems.Create<ProjectileFeature>());
      
      Add(systems.Create<EffectApplicationFeature>());
      Add(systems.Create<EffectFeature>());
      
      Add(systems.Create<SplineFeature>());
      Add(systems.Create<DeathFeature>());
      
      Add(systems.Create<MovementFeature>());
      
      Add(systems.Create<LevelBGMoveFeature>());
      Add(systems.Create<GameOverFeature>());
      
      Add(systems.Create<ProcessDestructedFeature>());
    }
  }
}