using Code.Infrastructure.View;
using UnityEngine;

namespace Code.Gameplay.Features.Player.StaticData
{
   [CreateAssetMenu(fileName = "Player Config", menuName = "Scriptable Objects/Player Config")]
   public class PlayerConfig : ScriptableObject
   {
      [field: SerializeField] public float Speed { get; private set; }
      [field: SerializeField] public int HP { get; private set; }
      [field: SerializeField] public EntityBehaviour Prefab { get; private set; }
   }
}