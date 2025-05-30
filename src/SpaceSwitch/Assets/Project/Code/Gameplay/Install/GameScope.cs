﻿using System;
using Code.Gameplay.Cameras.Provider;
using Code.Gameplay.Features.Effects.Factory;
using Code.Gameplay.Features.Enemy;
using Code.Gameplay.Features.Enemy.Services;
using Code.Gameplay.Features.EnemyLifetime.Factories;
using Code.Gameplay.Features.Player.Factories;
using Code.Gameplay.Features.Projectiles.Factories;
using Code.Gameplay.Features.Scrolling.Factories;
using Code.Gameplay.Features.Scrolling.Services;
using Code.Gameplay.Input.Service;
using Code.Gameplay.Levels;
using Code.Gameplay.StateMachine.States;
using Code.Gameplay.UI;
using Code.Infrastructure;
using Code.Infrastructure.Installers;
using Code.Infrastructure.States.Factory;
using Code.Infrastructure.States.StateMachine;
using Code.Infrastructure.Systems;
using Code.Infrastructure.View.Factory;
using Project.Code.Gameplay.Features.Cameras.Factories;
using Project.Code.Pause;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Code.Gameplay
{
   public class GameScope : LifetimeScope
   {
      [SerializeField] private ParentsInitializer _parentsInitializer;
      [SerializeField] private PauseView _pauseView;
      [SerializeField] private GameView _gameView;
      
      private IContainerBuilder _builder;
      
      protected override void Configure(IContainerBuilder builder)
      {
         _builder = builder;

         RegisterGameplayFactories();
         RegisterGameplayServices();

         RegisterCoreFactories();
         RegisterGameStateMachine();
         
         RegisterInitializers();
         RegisterPauseSystems();
         
         RegisterGameUI();

         _builder.RegisterEntryPoint<GameBootstrapper>();
      }

      private void RegisterGameUI()
      {
         _builder.Register<GameUIController>(Lifetime.Singleton).AsImplementedInterfaces();
         _builder.RegisterComponent(_gameView);
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
      }

      private void RegisterGameplayFactories()
      {
         _builder.Register<CameraFactory>(Lifetime.Singleton);
         _builder.Register<LevelPartsFactory>(Lifetime.Singleton);
         _builder.Register<PlayerFactory>(Lifetime.Singleton);
         _builder.Register<EnemyFactory>(Lifetime.Singleton);
         _builder.Register<EffectFactory>(Lifetime.Singleton);
         _builder.Register<EnemyScenarioFactory>(Lifetime.Singleton);
         _builder.Register<ProjectileFactory>(Lifetime.Singleton);
      }

      private void RegisterGameplayServices()
      {
         _builder.Register<GameInput>(Lifetime.Singleton).As<IDisposable>().AsSelf();
         _builder.Register<GameInputService>(Lifetime.Singleton).AsImplementedInterfaces();
         _builder.Register<CameraProvider>(Lifetime.Singleton).As<ICameraProvider>().AsSelf();
         _builder.Register<LevelDataProvider>(Lifetime.Singleton).As<ILevelDataProvider>();
         _builder.Register<EnemySpawnService>(Lifetime.Singleton).AsImplementedInterfaces().AsSelf();
         
         _builder.Register<LevelPartsHandleService>(Lifetime.Singleton);
         _builder.Register<LevelPartProvider>(Lifetime.Singleton);
      }

      private void RegisterPauseSystems()
      {
         _builder.Register<PauseService>(Lifetime.Singleton).AsImplementedInterfaces();
         _builder.RegisterComponent(_pauseView);
      }

      private void RegisterInitializers()
      {
         _builder.RegisterComponent(_parentsInitializer).AsImplementedInterfaces().AsSelf();
      }
   }
}