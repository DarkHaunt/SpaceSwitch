using System.Collections.Generic;
using UnityEngine;

namespace Code.Gameplay.Features.Player.Behaviors
{
   public class PlayerAnimator : MonoBehaviour
   {
      [SerializeField] private Transform _view;

      [field: Space]
      [SerializeField] private float _dampSpeed;
      [SerializeField] private float _maxAngle;

      [field: Header("--- Death ---")]
      [SerializeField] private float _deathTime;
      [SerializeField] private ParticleSystem _deathParticle;
      [SerializeField] private List<GameObject> _viewsToDisable;

      private float _velocity;
      private float _maxSpeed;
      private float _lastAngle;

      public void Init(float speed)
      {
         _maxSpeed = speed;
      }
      
      public float PlayDeathParticle()
      {
         foreach (GameObject view in _viewsToDisable)
            view.SetActive(false);
         
         _deathParticle.Play();
         return _deathTime;
      }

      public void UpdateViewRotationFromVelocity(Vector2 velocity, float timeStep)
      {
         float sign = velocity.x > 0 ? -1 : 1;
         float speed = Mathf.Abs(velocity.x);

         float speedPercent = Mathf.InverseLerp(0f, _maxSpeed, speed);
         float targetAngle = Mathf.Lerp(0f, _maxAngle, speedPercent) * sign;

         float angleDelta = Mathf.DeltaAngle(_lastAngle, targetAngle) * timeStep;
         float incomeAngle = Mathf.SmoothDamp(_lastAngle, _lastAngle + angleDelta, ref _velocity, _dampSpeed * timeStep);

         var angle = Mathf.Clamp(incomeAngle, -_maxAngle, _maxAngle);

         _lastAngle = angle;
         _view.localRotation = Quaternion.Euler(-90f, angle, 0f);
      }
   }
}