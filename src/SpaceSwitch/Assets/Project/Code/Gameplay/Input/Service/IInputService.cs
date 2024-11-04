using UnityEngine;

namespace Code.Gameplay.Input.Service
{
  public interface IInputService
  {
    bool HasAxisInput();
    bool HasAttackInput { get; }
    bool HasSwitchInput { get; }
     
    Vector2 GetInputDirection();
    void EnableInput(bool enabled);
    void CleanupInput();
  }
}