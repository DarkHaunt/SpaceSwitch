using System.Collections.Generic;
using Code.Gameplay.Input.Service;
using Entitas;

namespace Code.Gameplay.Input.Systems
{
   public sealed class CleanupEmittedInputSystem : ICleanupSystem
   {
      private readonly IInputService _inputService;
      
      private readonly IGroup<InputEntity> _inputs;
      private readonly List<InputEntity> _buffer = new(1);

      public CleanupEmittedInputSystem(InputContext context, IInputService inputService)
      {
         _inputService = inputService;
         _inputs = context.GetGroup(InputMatcher.AllOf
         (
            InputMatcher.Input
         ));
      }

      public void Cleanup()
      {
         foreach (InputEntity input in _inputs.GetEntities(_buffer))
         {
            _inputService.CleanupInput();
            
            input.isAttackRequested = false;
            input.isSwitchRequested = false;
         }
      }
   }
}