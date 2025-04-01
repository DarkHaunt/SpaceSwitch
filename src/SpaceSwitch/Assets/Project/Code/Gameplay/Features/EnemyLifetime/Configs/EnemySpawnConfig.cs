using System.Collections.Generic;
using Project.Code.Gameplay.Features.EnemyLifetime.Configs;
using UnityEngine;

namespace Code.Gameplay.Features.Enemy
{
   [CreateAssetMenu(fileName = "EnemySpawnConfig_X", menuName = "Scriptable Objects/Enemy Spawn Config")]
   public class EnemySpawnConfig : ScriptableObject
   {
      [field: SerializeField] public List<EnemySpawnScenario> SpawnScenarios { get; private set; }
   }
}