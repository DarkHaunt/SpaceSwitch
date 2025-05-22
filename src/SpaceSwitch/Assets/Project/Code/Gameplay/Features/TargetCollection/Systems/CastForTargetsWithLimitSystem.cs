using System;
using System.Collections.Generic;
using Entitas;
using Project.Code.Gameplay.Common.Physic;
using UnityEngine;

namespace Code.Gameplay.Features.TargetCollection.Systems
{
  public class CastForTargetsWithLimitSystem : IExecuteSystem, ITearDownSystem
  {
    private readonly IPhysicsService _physicsService;
    private readonly IGroup<GameEntity> _ready;
    private readonly List<GameEntity> _buffer = new(64);
    private GameEntity[] _targetCastBuffer = new GameEntity[128];

    public CastForTargetsWithLimitSystem(GameContext game, IPhysicsService physicsService)
    {
      _physicsService = physicsService;
      _ready = game.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.ReadyToCollectTargets,
          GameMatcher.TargetBuffer,
          GameMatcher.ProcessedTargets,
          GameMatcher.TargetLimit,
          GameMatcher.WorldPosition,
          GameMatcher.Collider,
          GameMatcher.LayerMask)
        .NoneOf(GameMatcher.ConsideringColorMatch)
      );
    }

    public void Execute()
    {
      foreach (GameEntity entity in _ready.GetEntities(_buffer))
      {
        for (int i = 0; i < Math.Min(TargetCountByEntityCollider(entity), entity.TargetLimit); i++)
        {
          int targetId = _targetCastBuffer[i].Id;

          if (!AlreadyProcessed(entity, targetId))
          {
            entity.TargetBuffer.Add(targetId);
            entity.ProcessedTargets.Add(targetId);
          }
        }

        if (!entity.isCollectingTargetsContinuously)
          entity.isReadyToCollectTargets = false;
      }
    }

    private bool AlreadyProcessed(GameEntity entity, int targetId)
    {
      return entity.ProcessedTargets.Contains(targetId);
    }

    private int TargetCountByEntityCollider(GameEntity entity)
    {
      return _physicsService.OverlapCollider(entity.Collider, entity.LayerMask, _targetCastBuffer);
    }

    public void TearDown()
    {
      _targetCastBuffer = null;
    }
  }
}