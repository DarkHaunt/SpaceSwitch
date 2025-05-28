using System.Collections.Generic;
using System.Linq;
using Entitas;
using Project.Code.Gameplay.Common.Physic;
using UnityEngine;

namespace Code.Gameplay.Features.TargetCollection.Systems
{
  public class CastForTargetsNoLimitSystem : IExecuteSystem, ITearDownSystem
  {
    private readonly IPhysicsService _physicsService;
    private readonly IGroup<GameEntity> _ready;
    private readonly List<GameEntity> _buffer = new(64);
    
    private GameEntity[] _targetCastBuffer = new GameEntity[1048];

    public CastForTargetsNoLimitSystem(GameContext game, IPhysicsService physicsService)
    {
      _physicsService = physicsService;
      _ready = game.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.ReadyToCollectTargets,
          GameMatcher.TargetBuffer,
          GameMatcher.WorldPosition,
          GameMatcher.LayerMask,
          GameMatcher.Collider)
        .NoneOf(GameMatcher.TargetLimit)
      );
    }

    public void Execute()
    {
      foreach (GameEntity entity in _ready.GetEntities(_buffer))
      {
        entity.TargetBuffer.AddRange(TargetsInRadius(entity));

        if (!entity.isCollectingTargetsContinuously)
          entity.isReadyToCollectTargets = false;
      }
    }
    
    private IEnumerable<int> TargetsInRadius(GameEntity entity)
    {
      var count = _physicsService.OverlapCollider(entity.Collider, entity.LayerMask, _targetCastBuffer);
      
      if (count == 0)
        return Enumerable.Empty<int>();
        
      return _targetCastBuffer
        .TakeWhile(x => x != null)
        .Select(x => x.Id);
    }

    public void TearDown()
    {
      _targetCastBuffer = null;
    }
  }
}