using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Code.Gameplay.Features.Enemy
{
   [CreateAssetMenu(fileName = "Enemy Config New", menuName = "Scriptable Objects/Enemy Config")]
   public class EnemyConfig : ScriptableObject
   {
      [field: SerializeField] public EnemyTypeId Id { get; private set; }
      [field: SerializeField] public AssetReferenceGameObject Prefab { get; private set; }
   }
}