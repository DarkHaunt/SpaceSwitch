﻿using System;
using Code.Gameplay.Cameras.Provider;
using Code.Gameplay.Features.Enemy;
using Code.Gameplay.Features.Player.Factories;
using Code.Gameplay.Features.Projectiles.Factories;
using Code.Gameplay.Features.Scrolling.Factories;
using Code.Gameplay.Features.Scrolling.Services;
using Code.Gameplay.Input.Service;
using Code.Gameplay.Levels;
using Code.Gameplay.StateMachine.States;
using Code.Gameplay.StaticData;
using Code.Infrastructure;
using Code.Infrastructure.States.Factory;
using Code.Infrastructure.States.GameStates;
using Code.Infrastructure.States.StateMachine;
using Code.Infrastructure.Systems;
using Code.Infrastructure.View.Factory;
using Code.Progress.Provider;
using Project.Code.Gameplay.Features.Cameras.Factories;
using VContainer;
using VContainer.Unity;

namespace Code.Gameplay
{
   public class GameScope : LifetimeScope
   {
      private IContainerBuilder _builder;
      
      protected override void Configure(IContainerBuilder builder)
      {
         _builder = builder;
         
         RegisterGameplayFactories();
         RegisterGameplayServices();

         RegisterCoreFactories();
         RegisterGameStateMachine();
         
         _builder.RegisterEntryPoint<GameBootstrapper>();
      }
      
      private void RegisterCoreFactories()
      {
         _builder.Register<EntityViewFactory>(Lifetime.Singleton).As<IEntityViewFactory>();
         _builder.Register<SystemFactory>(Lifetime.Singleton).As<ISystemFactory>();
         _builder.Register<StateFactory>(Lifetime.Singleton).As<IStateFactory>();
      }

      private void RegisterGameStateMachine()
      {
         _builder.Register<GameStateMachine>(Lifetime.Singleton).AsImplementedInterfaces();
         
         _builder.Register<GameBootstrapState>(Lifetime.Singleton).AsImplementedInterfaces().AsSelf();
         _builder.Register<GameLoopState>(Lifetime.Singleton).AsImplementedInterfaces().AsSelf();
         _builder.Register<GameOverState>(Lifetime.Singleton).AsImplementedInterfaces().AsSelf();
      }

      private void RegisterGameplayFactories()
      {
         _builder.Register<CameraFactory>(Lifetime.Singleton);
         _builder.Register<LevelPartsFactory>(Lifetime.Singleton);
         _builder.Register<PlayerFactory>(Lifetime.Singleton).As<IPlayerFactory>();
         _builder.Register<EnemyFactory>(Lifetime.Singleton).As<IEnemyFactory>();
         _builder.Register<ProjectileFactory>(Lifetime.Singleton).As<IProjectileFactory>();
      }
      
      private void RegisterGameplayServices()
      {
         _builder.Register<GameInput>(Lifetime.Singleton).As<IDisposable>().AsSelf();
         _builder.Register<GameInputService>(Lifetime.Singleton).AsImplementedInterfaces();
         _builder.Register<ProgressProvider>(Lifetime.Singleton).As<IProgressProvider>();
         _builder.Register<CameraProvider>(Lifetime.Singleton).As<ICameraProvider>().AsSelf();
         _builder.Register<StaticDataService>(Lifetime.Singleton).As<IStaticDataService>();
         _builder.Register<LevelDataProvider>(Lifetime.Singleton).As<ILevelDataProvider>();
         
         _builder.Register<LevelPartsHandleService>(Lifetime.Singleton);
         _builder.Register<LevelPartProvider>(Lifetime.Singleton);
      }
   }
}