using Code.Infrastructure.View;
using UnityEngine;

namespace Code.Gameplay.Features.Scrolling.Behaviors
{
   public class LevelPart : MonoBehaviour
   {
      [field: SerializeField] public int ID { get; private set; }
      [field: SerializeField] public EntityBehaviour View { get; private set; }
      
      [field: Space]
      [SerializeField] private Transform _leftBottom;
      [SerializeField] private Transform _topRight;

      public Vector3 LeftBottom => _leftBottom.position;
      public Vector3 TopRight => _topRight.position;
   }
}