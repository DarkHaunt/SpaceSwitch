using System.Linq;
using UnityEngine;
using UnityEngine.Splines;

namespace Code.Gameplay.Features.Enemy.Behaviors
{
   public class EnemyPath : MonoBehaviour
   {
      [field: SerializeField] public SplineContainer Path { get; private set; }
   }
}