using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Code.Gameplay.Features.Player.StaticData
{
   [CreateAssetMenu(fileName = "Player Config", menuName = "Scriptable Objects/Player Config")]
   public class PlayerConfig : ScriptableObject
   {
      [field: SerializeField] public AssetReferenceGameObject Prefab { get; private set; }
   }
}