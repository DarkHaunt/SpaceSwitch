using System;
using Code.Common.Extra;
using Code.Gameplay.Features.ColorSwitch.StaticData;
using Code.Gameplay.Features.Enemy;

namespace Project.Code.Gameplay.Features.Enemy.Configs
{
   [Serializable]
   public class EnemySpawnData : SerializationNameReceiver
   {
      public float TimeToSpawn;
      public bool RotateToPath = true;
      public EnemyTypeId Id;
      public ColorType Color;
      
      protected override string ReceiveName() =>
         Id.ToString();
   }
}