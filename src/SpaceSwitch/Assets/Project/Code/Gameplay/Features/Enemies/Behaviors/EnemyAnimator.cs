using System.Collections.Generic;
using UnityEngine;

namespace Code.Gameplay.Features.Enemy.Behaviors
{
   public class EnemyAnimator : MonoBehaviour
   {
      [field: Header("--- Death ---")]
      [SerializeField] private float _deathTime;
      [SerializeField] private ParticleSystem _deathParticle;
      [SerializeField] private List<GameObject> _viewsToDisable;

      public float PlayDeathParticle()
      {
         foreach (var view in _viewsToDisable)
            view.SetActive(false);

         _deathParticle.Play();
         return _deathTime;
      }
   }
}