﻿using Code.Common.Destruct;
using Code.Gameplay.Features.Lifetime.Systems;
using Code.Gameplay.Features.Movement;
using Code.Gameplay.Features.TargetCollection;
using Code.Gameplay.Input;
using Code.Infrastructure.Systems;
using Code.Infrastructure.View;

namespace Code.Gameplay
{
  public class BattleFeature : Feature
  {
    public BattleFeature(ISystemFactory systems)
    {
      Add(systems.Create<InputFeature>());
      Add(systems.Create<BindViewFeature>());
      
      Add(systems.Create<DeathFeature>());
      Add(systems.Create<MovementFeature>());
 
      Add(systems.Create<CollectTargetsFeature>());
      Add(systems.Create<ProcessDestructedFeature>());
    }
  }
}