using System;
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
using Code.Infrastructure.States.Factory;
using Code.Infrastructure.States.GameStates;
using Code.Infrastructure.States.StateMachine;
using Code.Infrastructure.Systems;
using Code.Infrastructure.View.Factory;
using Code.Progress.Provider;
using Code.Progress.SaveLoad;
using Project.Code.Common.Infrastructure.CoroutineRunner;
using Project.Code.Common.Infrastructure.SceneLoader;
using Project.Code.Common.UI.LoadingCurtain;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Code.Infrastructure.Installers
{
  public class ProjectInstaller : LifetimeScope
  {
    [SerializeField] private CoroutineRunner _coroutineRunner;
    [SerializeField] private LoadingCurtain _loadingCurtain;
    
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
      BindCommonUI();

      BindGameStateMachine();
    }

    private void BindGameStateMachine()
    {
      _builder.Register<GameStateMachine>(Lifetime.Singleton).AsImplementedInterfaces();
      _builder.Register<StateFactory>(Lifetime.Singleton).As<IStateFactory>();
      
      _builder.Register<BootstrapState>(Lifetime.Singleton).AsImplementedInterfaces().AsSelf();
      _builder.Register<MenuLoopState>(Lifetime.Singleton).AsImplementedInterfaces().AsSelf();
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
      _builder.Register<GameInput>(Lifetime.Singleton).As<IDisposable>().AsSelf();
      _builder.Register<GameInputService>(Lifetime.Singleton).AsImplementedInterfaces();
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
      _builder.RegisterEntryPoint<GameBootstrapper>();
       
      _builder
        .RegisterComponentInNewPrefab(_coroutineRunner, Lifetime.Singleton)
        .As<ICoroutineRunner>();
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
      _builder.Register<WindowService>(Lifetime.Singleton).As<IWindowService>();
      _builder.Register<WindowFactory>(Lifetime.Singleton).As<IWindowFactory>();
    }

    private void BindCommonUI()
    {
      _builder.RegisterComponentInNewPrefab(_loadingCurtain, Lifetime.Singleton).As<ILoadingCurtain>();
    }
  }
}