using System.Collections.Generic;
using Code.Gameplay.Features.ColorSwitch.StaticData;
using UnityEngine;

namespace Code.Gameplay.Features.Projectiles.Behaviors
{
   public class ProjectileAnimator : MonoBehaviour
   {
      [field: Header("--- Death ---")]
      [SerializeField] private float _deathTime;
      
      [field: Space]
      [SerializeField] private ParticleSystem _redColor;
      [SerializeField] private ParticleSystem _blueColor;
      [SerializeField] private List<GameObject> _viewsToDisable;

      
      public float PlayDeathParticle(ColorType color)
      {
         foreach (GameObject view in _viewsToDisable)
            view.SetActive(false);
         
         switch (color)
         {
            case ColorType.Red:
               _redColor.Play();
               break;
            case ColorType.Blue:
               _blueColor.Play();
               break;
         }

         return _deathTime;
      }
   }
}