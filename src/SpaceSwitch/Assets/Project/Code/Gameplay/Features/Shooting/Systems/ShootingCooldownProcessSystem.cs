using System.Collections.Generic;
using Code.Gameplay.Common;
using Code.Gameplay.Common.Time;
using Entitas;

namespace Code.Gameplay.Features.Shooting.Systems
{
   public sealed class ShootingCooldownProcessSystem : IExecuteSystem
   {
      private readonly List<GameEntity> _buffer = new (16);
      
      private readonly IGroup<GameEntity> _timers;
      private readonly ITimeService _time;

      public ShootingCooldownProcessSystem(GameContext context, ITimeService time)
      {
         _time = time;
         _timers = context.GetGroup(GameMatcher
            .AllOf(
               GameMatcher.ShootTimer
            ));
      }

      public void Execute()
      {
         foreach (GameEntity timer in _timers.GetEntities(_buffer))
         {
            timer.ReplaceShootTimer(timer.ShootTimer - _time.DeltaTime);
            
            if (timer.ShootTimer <= 0)
               timer.RemoveShootTimer();
         }
      }
   }
}