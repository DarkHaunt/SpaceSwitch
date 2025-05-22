using System;
using System.Collections.Generic;
using Code.Gameplay.Features.ColorSwitch.StaticData;
using Entitas;
using Project.Code.Gameplay.Common.Physic;
using UnityEngine;

namespace Code.Gameplay.Features.TargetCollection.Systems
{
   public class CastForTargetsWithLimitByColorSystem : IExecuteSystem, ITearDownSystem
   {
      private readonly IPhysicsService _physicsService;
      private readonly IGroup<GameEntity> _ready;
      private readonly List<GameEntity> _buffer = new(64);
      private GameEntity[] _targetCastBuffer = new GameEntity[128];

      public CastForTargetsWithLimitByColorSystem(GameContext game, IPhysicsService physicsService)
      {
         _physicsService = physicsService;
         _ready = game.GetGroup(GameMatcher
            .AllOf(
               GameMatcher.ReadyToCollectTargets,
               GameMatcher.TargetBuffer,
               GameMatcher.ProcessedTargets,
               GameMatcher.TargetLimit,
               GameMatcher.WorldPosition,
               GameMatcher.LayerMask,
               GameMatcher.Collider,
               GameMatcher.ConsideringColorMatch,
               GameMatcher.ColorType)
         );
      }

      public void Execute()
      {
         foreach (GameEntity entity in _ready.GetEntities(_buffer))
         {
            for (int i = 0; i < Math.Min(TargetCountInRadius(entity), entity.TargetLimit); i++)
            {
               int targetId = _targetCastBuffer[i].Id;

               if (AlreadyProcessed(entity, targetId) == false)
               {
                  if (ColorMatched(entity, _targetCastBuffer[i]))
                  {
                     //Debug.Log($"<color=white>{entity.Id} proj {entity.isProjectile} collected target {targetId} lim {entity.TargetLimit} target in radius {TargetCountInRadius(entity)}</color>");
                     entity.TargetBuffer.Add(targetId);
                     entity.ProcessedTargets.Add(targetId);
                  }
               }
            }

            if (!entity.isCollectingTargetsContinuously)
               entity.isReadyToCollectTargets = false;
         }
      }

      private bool ColorMatched(GameEntity caster, GameEntity target)
      {
         if(caster.ColorType == ColorType.NoneMatchedColor || target.hasColorType == false)
            return false;

         return caster.ColorType switch
         {
            ColorType.AllMatchedColor => true,
            ColorType.Unknown => throw new Exception("Caster color type is unknown"),
            _ => caster.ColorType == target.ColorType
         };
      }

      private bool AlreadyProcessed(GameEntity entity, int targetId)
      {
         return entity.ProcessedTargets.Contains(targetId);
      }

      private int TargetCountInRadius(GameEntity entity)
      {
         return _physicsService.OverlapCollider(entity.Collider, entity.LayerMask, _targetCastBuffer);
      }

      public void TearDown()
      {
         _targetCastBuffer = null;
      }
   }
}