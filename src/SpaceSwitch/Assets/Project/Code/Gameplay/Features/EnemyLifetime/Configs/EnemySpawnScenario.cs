using System;
using System.Collections.Generic;
using Project.Code.Gameplay.Features.Enemy.Configs;
using UnityEngine.Splines;

namespace Project.Code.Gameplay.Features.EnemyLifetime.Configs
{
   [Serializable]
   public class EnemySpawnScenario
   {
      public float TimeToSpawn;
      public SplineContainer Spline;
      public List<EnemySpawnData> Enemies;
   }
}