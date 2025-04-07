using Code.Gameplay.Features.Effects;
using Code.Gameplay.Features.Effects.Factory;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.EffectApplication.Systems
{
  public class ApplyEffectsOnTargetsSystem : IExecuteSystem
  {
    private readonly EffectFactory _effectFactory;
    private readonly IGroup<GameEntity> _entities;

    public ApplyEffectsOnTargetsSystem(GameContext game, EffectFactory effectFactory)
    {
      _effectFactory = effectFactory;
      _entities = game.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.TargetBuffer,
          GameMatcher.EffectSetups));
    }
    
    public void Execute()
    {
      foreach (GameEntity entity in _entities)
      {
        foreach (int targetId in entity.TargetBuffer)
        {
          foreach (EffectSetup setup in entity.EffectSetups)
          {
            _effectFactory.CreateEffect(setup, ProducerId(entity), targetId);
          }
        }
      }
    }

    private static int ProducerId(GameEntity entity)
    {
      return entity.hasProducerId ? entity.ProducerId : entity.Id;
    }
  }
}