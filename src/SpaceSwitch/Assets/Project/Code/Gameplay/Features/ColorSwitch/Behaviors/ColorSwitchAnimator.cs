using System.Collections.Generic;
using Code.Gameplay.Features.ColorSwitch.StaticData;
using UnityEngine;

namespace Code.Gameplay.Features.ColorSwitch.Behaviors
{
   public class ColorSwitchAnimator : MonoBehaviour
   {
      [SerializeField] private ColorSwitchMode _switchMode = ColorSwitchMode.MaterialSwitch;

      [field: Header("--- Object Switch  ---")]
      [SerializeField] private GameObject _redObject;
      [SerializeField] private GameObject _blueObject;
      [SerializeField] private List<GameObject> _disableObjects;
      
      [field: Header("--- Material Switch ---")]
      [SerializeField] private MeshRenderer _renderer;
      
      [field: Space]
      [SerializeField] private Material[] _redMaterials;
      [SerializeField] private Material[] _blueMaterials;


      private void Awake()
      {
         if (_switchMode == ColorSwitchMode.ObjectSwitch)
            _disableObjects.ForEach(x => x.gameObject.SetActive(false));
      }

      public void SetColor(ColorType colorType)
      {
         switch (_switchMode)
         {
            case ColorSwitchMode.MaterialSwitch:
               _renderer.materials = colorType switch
               {
                  ColorType.Red => _redMaterials,
                  ColorType.Blue => _blueMaterials,

                  _ => _renderer.materials
               };
               break;
            case ColorSwitchMode.ObjectSwitch:
               var enableRed = colorType == ColorType.Red;
               
               _redObject.gameObject.SetActive(enableRed);
               _blueObject.gameObject.SetActive(!enableRed);
               break;
         }
         
      }

      private enum ColorSwitchMode
      {
         Unknown = 0,
         
         MaterialSwitch = 1,
         ObjectSwitch = 2,
      }
   }
}