using System;
using Code.Common.Extensions;
using UnityEngine;

namespace Code.Gameplay.Features.Player.Behaviors
{
   public class PlayerAnimator : MonoBehaviour
   {
      [SerializeField] private Transform _view;

      [field: Space]
      [SerializeField] private float _rightAngle;
      [SerializeField] private float _leftAngle;

      private float _leftTargetSpeed;
      private float _rightTargetSpeed;
      private Vector3 _originRotation;

      private void Awake()
      {
         _originRotation = _view.localRotation.eulerAngles;
      }

      public void Init(float speed)
      {
         _leftTargetSpeed = -speed;
         _rightTargetSpeed = speed;
      }

      public void UpdateViewRotationFromVelocity(Vector2 velocity)
      {
         var xSpeed = velocity.x;
         var speedPercent = Mathf.InverseLerp(_leftTargetSpeed, _rightTargetSpeed, xSpeed);
         var angle = Mathf.Lerp(_rightAngle, _leftAngle, speedPercent);

         Debug.Log($"<color=white>Angle - {angle} - {velocity}</color>");
         
         _view.eulerAngles = _originRotation.SetZ(angle);
      }
   }
}