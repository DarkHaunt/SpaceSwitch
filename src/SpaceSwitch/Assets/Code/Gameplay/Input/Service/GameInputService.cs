using System;
using Code.Infrastructure;
using UnityEngine;
using UnityEngine.InputSystem;
using VContainer.Unity;

namespace Code.Gameplay.Input.Service
{
  public class GameInputService : IInputService, IInitializable, IDisposable
  {
    public bool HasAttackInput { get; private set; }
    public bool HasSwitchInput { get; private set; } 

    private readonly GameInput _input;

    public GameInputService(GameInput input)
    {
      _input = input;
    }

    public void Initialize()
    {
      _input.Game.Attack.performed += SetAttackInput;
      _input.Game.Switch.performed += SetSwitchInput;
    }

    public void Dispose()
    {
      _input.Game.Attack.performed -= SetAttackInput;
      _input.Game.Switch.performed -= SetSwitchInput;
      
      _input?.Dispose();
    }

    public void EnableInput(bool enabled) 
    {
      if (enabled)
        _input.Enable();
      else
        _input.Disable();
    }

    public void CleanupInput()
    {
       HasSwitchInput = false;
       HasAttackInput = false;
    }

    public bool HasAxisInput() => 
      GetInputDirection() != Vector2.zero;

    public Vector2 GetInputDirection() =>
      _input.Game.MoveDirection.ReadValue<Vector2>();

    private void SetAttackInput(InputAction.CallbackContext obj) =>
      HasAttackInput = true;

    private void SetSwitchInput(InputAction.CallbackContext obj) =>
      HasSwitchInput = true;
  }
}