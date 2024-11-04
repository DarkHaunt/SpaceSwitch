using Code.Gameplay.Input.Systems;
using Code.Infrastructure.Systems;
using UnityEngine;

namespace Code.Gameplay.Input
{
  public class InputFeature : Feature
  {
    public InputFeature(ISystemFactory systems)
    {
      Add(systems.Create<InitializeInputSystem>());
      Add(systems.Create<EmitInputSystem>());
      
      Add(systems.Create<CleanupEmittedInputSystem>());
    }
  }
}