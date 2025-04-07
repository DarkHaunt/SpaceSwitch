using System.Collections.Generic;
using Code.Gameplay.Features.Effects;
using Code.Infrastructure.View;
using UnityEngine;

namespace Code.Gameplay.Features.Projectiles
{
   [CreateAssetMenu(fileName = "Projectile Config New", menuName = "Scriptable Objects/Projectile Config")]
   public class ProjectileConfig : ScriptableObject
   {
      [field: SerializeField] public ProjectileTypeId Id { get; private set; }

      [field: Space]
      [field: SerializeField] public float Speed { get; private set; }
      [field: SerializeField] public float Damage { get; private set; }
      [field: SerializeField] public float ContactRadius { get; private set; }
      [field: SerializeField] public EntityBehaviour Prefab { get; private set; }

      [field: Header("--- Effects ---")]
      [field: SerializeField] public List<EffectSetup> Effects { get; private set; }
   }
}