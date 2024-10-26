using Code.Gameplay.Cameras.Provider;
using Code.Gameplay.Common.Collisions;
using Code.Gameplay.Common.Physics;
using Code.Gameplay.Common.Random;
using Code.Gameplay.Common.Time;
using Code.Gameplay.Input.Service;
using Code.Gameplay.Levels;
using Code.Gameplay.StaticData;
using Code.Gameplay.Windows;
using Code.Infrastructure.AssetManagement;
using Code.Infrastructure.Identifiers;
using Code.Infrastructure.Loading;
using Code.Infrastructure.States.Factory;
using Code.Infrastructure.States.GameStates;
using Code.Infrastructure.States.StateMachine;
using Code.Infrastructure.Systems;
using Code.Infrastructure.View.Factory;
using Code.Progress.Provider;
using Code.Progress.SaveLoad;
using VContainer;
using VContainer.Unity;

namespace Code.Infrastructure.Installers
{
  public class BootstrapInstaller : LifetimeScope, ICoroutineRunner
  {
    private IContainerBuilder _builder;

    protected override void Configure(IContainerBuilder builder)
    {
      _builder = builder;

      BindInfrastructureServices();
      BindCommonServices();
      
      BindContexts();
      
      BindGameplayServices();
      BindGameplayFactories();
      
      BindUIServices();
      BindUIFactories();
      
      BindStateMachine();
      BindStateFactory();
      BindGameStates();
    }

    private void BindStateMachine()
    {
      _builder.Register<GameStateMachine>(Lifetime.Singleton);
    }

    private void BindStateFactory()
    {
      _builder.Register<StateFactory>(Lifetime.Singleton);
    }

    private void BindGameStates()
    {
      _builder.Register<BootstrapState>(Lifetime.Singleton).AsImplementedInterfaces().AsSelf();
      _builder.Register<GameLoopState>(Lifetime.Singleton).AsImplementedInterfaces().AsSelf();
      _builder.Register<GameOverState>(Lifetime.Singleton).AsImplementedInterfaces().AsSelf();
    }

    private void BindContexts()
    {
      _builder.RegisterInstance(Contexts.sharedInstance);
      
      _builder.RegisterInstance(Contexts.sharedInstance.game);
      _builder.RegisterInstance(Contexts.sharedInstance.input);
      _builder.RegisterInstance(Contexts.sharedInstance.meta);
    }

    private void BindGameplayServices()
    {
      _builder.Register<StandaloneInputService>(Lifetime.Singleton).As<IInputService>();
      _builder.Register<ProgressProvider>(Lifetime.Singleton).As<IProgressProvider>();
      _builder.Register<CameraProvider>(Lifetime.Singleton).As<ICameraProvider>().AsSelf();
      _builder.Register<StaticDataService>(Lifetime.Singleton).As<IStaticDataService>();
      _builder.Register<LevelDataProvider>(Lifetime.Singleton).As<ILevelDataProvider>();
    }

    private void BindGameplayFactories()
    {
      _builder.Register<EntityViewFactory>(Lifetime.Singleton).As<IEntityViewFactory>();
      _builder.Register<SystemFactory>(Lifetime.Singleton).As<ISystemFactory>();
    }

    private void BindInfrastructureServices()
    {
      _builder.Register<SaveLoadService>(Lifetime.Singleton).As<ISaveLoadService>();
      _builder.Register<AssetProvider>(Lifetime.Singleton).As<IAssetProvider>();
      _builder.Register<IdentifierService>(Lifetime.Singleton).As<IIdentifierService>();
      _builder.Register<GameBootstrapper>(Lifetime.Singleton).AsImplementedInterfaces();
      
      _builder.RegisterInstance(this).AsImplementedInterfaces();
    }

    private void BindCommonServices()
    {
      _builder.Register<UnityRandomService>(Lifetime.Singleton).As<IRandomService>();
      _builder.Register<CollisionRegistry>(Lifetime.Singleton).As<ICollisionRegistry>();
      _builder.Register<PhysicsService>(Lifetime.Singleton).As<IPhysicsService>();
      _builder.Register<SceneLoader>(Lifetime.Singleton).As<ISceneLoader>();
      _builder.Register<UnityTimeService>(Lifetime.Singleton).As<ITimeService>();
    }

    private void BindUIServices()
    {
      _builder
        .Register<WindowService>(Lifetime.Singleton)
        .As<IWindowService>();
    }

    private void BindUIFactories()
    {
      _builder
        .Register<WindowFactory>(Lifetime.Singleton)
        .As<IWindowFactory>();
    }
  }
}