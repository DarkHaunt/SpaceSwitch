using Code.Infrastructure.View;
using UnityEngine;

namespace Code.Gameplay.Features.Enemy
{
   [CreateAssetMenu(fileName = "Enemy Config New", menuName = "Scriptable Objects/Enemy Config")]
   public class EnemyConfig : ScriptableObject
   {
      [field: SerializeField] public EnemyTypeId Id { get; private set; }
      [field: SerializeField] public EntityBehaviour Prefab { get; private set; }

      [field: Space]
      [field: SerializeField] public float ContactRadius { get; private set; }
      [field: SerializeField] public float Speed { get; private set; }
      [field: SerializeField] public float Health { get; private set; }
      [field: SerializeField] public int Score { get; private set; }
   }
}