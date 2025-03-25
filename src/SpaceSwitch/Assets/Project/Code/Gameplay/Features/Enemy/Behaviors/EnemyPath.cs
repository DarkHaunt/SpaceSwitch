using System.Linq;
using UnityEngine;
using UnityEngine.Splines;

namespace Code.Gameplay.Features.Enemy.Behaviors
{
   public class EnemyPath : MonoBehaviour
   {
      [field: SerializeField] public SplineContainer Path { get; private set; }
      
      public Vector3 HighestPoint { get; private set; }

      private void Awake()
      {
         HighestPoint  = Path.Splines
            .SelectMany(x => x.Knots)
            .OrderByDescending( x => x.Position.y)
            .First().Position;
      }
   }
}