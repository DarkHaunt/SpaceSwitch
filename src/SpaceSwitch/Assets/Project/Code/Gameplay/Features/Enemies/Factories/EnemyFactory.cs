using System;
using System.Collections.Generic;
using System.Linq;
using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Gameplay.Features.Effects;
using Code.Gameplay.StaticData;
using Code.Infrastructure.Identifiers;
using Project.Code.Gameplay.Features.Enemy.Configs;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Splines;

namespace Code.Gameplay.Features.Enemy
{
   public class EnemyFactory
   {
      private readonly IIdentifierService _identifiers;
      private readonly IStaticDataService _staticData;
      
      private Transform _root;

      public EnemyFactory(IIdentifierService identifiers, IStaticDataService staticData)
      {
         _identifiers = identifiers;
         _staticData = staticData;
      }

      public GameEntity CreateEnemy(EnemySpawnData data, Spline spline)
      {
         EnemyTypeId typeId = data.Id;
         
         GameEntity entity = typeId switch
         {
            EnemyTypeId.Simple => CreateSimple(),

            _ => throw new Exception($"Enemy with type id {typeId} does not exist")
         };
         
         entity = AddSharedComponents(entity, data, spline);

         return entity;
      }

      private GameEntity AddSharedComponents(GameEntity enemy, EnemySpawnData data, Spline spline)
      {
         EnemyConfig config = _staticData.GetEnemyConfigWithId(data.Id);
         float3 startPos = spline.Knots.First().Position;
         
         enemy
            .AddId(_identifiers.Next())
            .AddViewPrefab(config.Prefab)
            .AddEnemyTypeId(data.Id)
            
            .AddColorType(data.Color)
            
            .AddWorldPosition(startPos)
            .AddWorldRotation(Quaternion.identity)
            
            .AddLayerMask(CollisionLayer.Player.AsMask())
            .AddRadius(config.ContactRadius)
            
            .AddSpeed(config.Speed)
            .AddCurrentHp(config.Health)
            .AddMaxHp(config.Health)
            
            .AddScore(config.Score)
            
            .AddTargetBuffer(new List<int>(1))
            .AddProcessedTargets(new List<int>(1))
            .AddEffectSetups(new List<EffectSetup>{ new(EffectTypeId.Damage, float.MaxValue) }) // Insta kill for player
            
            .With(x => x.isMovementAvailable = true)
            .With(x => x.isRotationAlignedAlongDirection = data.RotateToPath)
            
            .AddSpline(spline)
            .AddSplineTPosition(0)
            .With(x => x.isMovingSpline = true)
            
            .With(x => x.isCollectingTargetsContinuously = true)
            .With(x => x.isReadyToCollectTargets = true)
            .With(x => x.isEnemy = true)
            
            ;
         
         return enemy;
      }

      private GameEntity CreateSimple()
      {
         return CreateGameEntity.Empty()
            
            ;
      }
   }
}