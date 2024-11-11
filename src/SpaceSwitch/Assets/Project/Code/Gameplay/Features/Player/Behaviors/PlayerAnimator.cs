using UnityEngine;

namespace Code.Gameplay.Features.Player.Behaviors
{
   public class PlayerAnimator : MonoBehaviour
   {
      [SerializeField] private Transform _view;

      [field: Space]
      [SerializeField] private float _dampSpeed;
      [SerializeField] private float _maxAngle;

      private float _velocity;
      private float _maxSpeed;

      public void Init(float speed)
      {
         _maxSpeed = speed;
      }

      public void UpdateViewRotationFromVelocity(Vector2 velocity, float timeStep)
      {
         /*float sign = velocity.x > 0 ? 1 : -1;
         float speed = Mathf.Abs(velocity.x);

         float speedPercent = Mathf.InverseLerp(0f, _maxSpeed, speed);
         float targetAngle = Mathf.Lerp(0f, _rightAngle, speedPercent) * sign;

         float currentAngle = _view.eulerAngles.z;
         float angleDelta = Mathf.DeltaAngle(currentAngle, targetAngle) * timeStep;
         float smoothAngle = Mathf.SmoothDamp(currentAngle, currentAngle + angleDelta, ref _velocity, _dampSpeed * timeStep);

         var clamped = Mathf.Clamp(smoothAngle, -_rightAngle, _rightAngle);

         Debug.Log($"<color=white>{clamped}</color>");

         _view.rotation = Quaternion.Euler(_view. ); new Vector3(-90f, 0f, clamped);*/
      }
   }
}