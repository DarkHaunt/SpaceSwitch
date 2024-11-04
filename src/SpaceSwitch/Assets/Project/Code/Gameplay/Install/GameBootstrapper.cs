using Code.Infrastructure.States.StateMachine;
using Cysharp.Threading.Tasks;
using VContainer.Unity;
using System.Threading;
using Code.Gameplay.StateMachine.States;
using UnityEngine;

namespace Code.Gameplay
{
   public sealed class GameBootstrapper : IStartable
   {
      private readonly IGameStateMachine _gameStateMachine;

      public GameBootstrapper(IGameStateMachine gameStateMachine)
      {
         _gameStateMachine = gameStateMachine;
      }

      public void Start() =>
         _gameStateMachine.Enter<GameBootstrapState>();
   }
}