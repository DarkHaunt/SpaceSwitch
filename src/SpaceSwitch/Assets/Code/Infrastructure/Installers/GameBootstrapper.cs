using System;
using Code.Infrastructure.States.GameStates;
using Code.Infrastructure.States.StateMachine;
using RSG;
using UnityEngine;
using VContainer.Unity;

namespace Code.Infrastructure.Installers
{
   public class GameBootstrapper : IInitializable, IDisposable
   {
      private readonly IGameStateMachine _gameStateMachine;

      public GameBootstrapper(IGameStateMachine gameStateMachine)
      {
         _gameStateMachine = gameStateMachine;
      }
      
      public void Initialize()
      {
         Promise.UnhandledException += LogPromiseException;
         _gameStateMachine.Enter<BootstrapState>();
      }

      public void Dispose()
      {
         Promise.UnhandledException -= LogPromiseException;
      }

      private void LogPromiseException(object sender, ExceptionEventArgs e) =>
         Debug.LogException(e.Exception);
   }
}