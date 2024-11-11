using Code.Gameplay.Features.ColorSwitch.StaticData;
using UnityEngine;

namespace Code.Gameplay.Features.ColorSwitch.Behaviors
{
   public class ColorSwitchAnimator : MonoBehaviour
   {
      [SerializeField] private MeshRenderer _renderer;
      
      [field: Space]
      [SerializeField] private Material[] _redMaterials;
      [SerializeField] private Material[] _blueMaterials;


      public void SetColor(ColorType colorType)
      {
         _renderer.materials = colorType switch
         {
            ColorType.Red => _redMaterials,
            ColorType.Blue => _blueMaterials,
            
            _ => _renderer.materials
         };
      }
   }
}