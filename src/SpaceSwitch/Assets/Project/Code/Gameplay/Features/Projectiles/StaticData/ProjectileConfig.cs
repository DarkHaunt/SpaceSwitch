﻿using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Code.Gameplay.Features.Projectiles
{
   [CreateAssetMenu(fileName = "Projectile Config New", menuName = "Scriptable Objects/Projectile Config")]
   public class ProjectileConfig : ScriptableObject
   {
      [field: SerializeField] public ProjectileTypeId Id { get; private set; }
      [field: SerializeField] public AssetReferenceGameObject Prefab { get; private set; }
   }
}