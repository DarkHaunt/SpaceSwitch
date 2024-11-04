using Code.Common.Entity;
using Code.Gameplay.Input.Service;
using Entitas;

namespace Code.Gameplay.Input.Systems
{
  public class InitializeInputSystem : IInitializeSystem
  {
    private readonly IInputService _inputService;

    public InitializeInputSystem(IInputService inputService)
    {
      _inputService = inputService;
    }
    
    public void Initialize()
    {
      _inputService.EnableInput(true);
      
      CreateInputEntity.Empty()
        .isInput = true;
    }
  }
}