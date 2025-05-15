using System;
using System.Collections.Generic;
using Code.Common.Extra;
using Project.Code.Gameplay.Features.Enemy.Configs;
using UnityEngine.Splines;

namespace Project.Code.Gameplay.Features.EnemyLifetime.Configs
{
   [Serializable]
   public class EnemySpawnScenario : SerializationNameReceiver
   {
      public float TimeToSpawn;
      public SplineContainer Spline;
      public List<EnemySpawnData> Enemies;
      protected override string ReceiveName() =>
         Spline == null ? "Null" : Spline.name;
   }
}