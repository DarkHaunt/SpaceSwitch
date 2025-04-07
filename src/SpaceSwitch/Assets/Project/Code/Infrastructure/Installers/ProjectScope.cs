using Code.Gameplay.Common.Collisions;
using Code.Gameplay.Common.Random;
using Code.Gameplay.Common.Time;
using Code.Gameplay.Score;
using Code.Gameplay.StaticData;
using Code.Gameplay.Windows;
using Code.Infrastructure.AssetManagement;
using Code.Infrastructure.Identifiers;
using Code.Progress.Provider;
using Code.Progress.SaveLoad;
using Project.Code.Common.Infrastructure.CoroutineRunner;
using Project.Code.Common.Infrastructure.SceneLoader;
using Project.Code.Common.UI.LoadingCurtain;
using Project.Code.Gameplay.Common.Physic;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Code.Infrastructure.Installers
{
  public class ProjectScope : LifetimeScope
  {
    [SerializeField] private CoroutineRunner _coroutineRunner;
    [SerializeField] private LoadingCurtain _loadingCurtain;
    
    private IContainerBuilder _builder;

    protected override void Configure(IContainerBuilder builder)
    {
      _builder = builder;

      RegisterInfrastructureServices();
      RegisterCommonServices();
      
      RegisterContexts();
      
      RegisterUIServices();
      RegisterCommonUI();
    }

    private void RegisterContexts()
    {
      _builder.RegisterInstance(Contexts.sharedInstance);
      
      _builder.RegisterInstance(Contexts.sharedInstance.game);
      _builder.RegisterInstance(Contexts.sharedInstance.input);
      _builder.RegisterInstance(Contexts.sharedInstance.meta);
    }

    private void RegisterInfrastructureServices()
    {
      _builder.Register<ProgressProvider>(Lifetime.Singleton).As<IProgressProvider>();
      _builder.Register<StaticDataService>(Lifetime.Singleton).As<IStaticDataService>();
      _builder.Register<SaveLoadService>(Lifetime.Singleton).As<ISaveLoadService>();
      _builder.Register<AssetProvider>(Lifetime.Singleton).As<IAssetProvider>();
      _builder.Register<SceneLoader>(Lifetime.Singleton).As<ISceneLoader>();
      _builder.Register<IdentifierService>(Lifetime.Singleton).As<IIdentifierService>();
      _builder.Register<ScoreService>(Lifetime.Singleton);
      _builder.RegisterEntryPoint<RootBootstrapper>();
       
      _builder
        .RegisterComponentInNewPrefab(_coroutineRunner, Lifetime.Singleton)
        .DontDestroyOnLoad()
        .As<ICoroutineRunner>();
    }

    private void RegisterCommonServices()
    {
      _builder.Register<UnityRandomService>(Lifetime.Singleton).As<IRandomService>();
      _builder.Register<CollisionRegistry>(Lifetime.Singleton).As<ICollisionRegistry>();
      _builder.Register<PhysicsService>(Lifetime.Singleton).As<IPhysicsService>();
      _builder.Register<UnityTimeService>(Lifetime.Singleton).As<ITimeService>();
    }

    private void RegisterUIServices()
    {
      _builder.Register<WindowService>(Lifetime.Singleton).As<IWindowService>();
      _builder.Register<WindowFactory>(Lifetime.Singleton).As<IWindowFactory>();
    }

    private void RegisterCommonUI()
    {
      _builder
        .RegisterComponentInNewPrefab(_loadingCurtain, Lifetime.Singleton)
        .DontDestroyOnLoad()
        .As<ILoadingCurtain>();
    }
  }
}