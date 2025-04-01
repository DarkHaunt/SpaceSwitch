using Code.Gameplay.Common.Time;
using Entitas;

namespace Code.Gameplay.Features.Enemy.Systems
{
   public sealed class ProcessEnemySpawnTimerSystem : IExecuteSystem
   {
      private readonly IGroup<GameEntity> _timers;
      private readonly ITimeService _time;

      public ProcessEnemySpawnTimerSystem(GameContext context, ITimeService time)
      {
         _time = time;
         _timers = context.GetGroup(GameMatcher
            .AllOf(
               GameMatcher.EnemySpawnTimer,
               GameMatcher.EnemySpawnTimeLeft,
               GameMatcher.SpawningEnemies
            )
            .NoneOf(GameMatcher.ReadyToSpawnNextEnemy));
      }

      public void Execute()
      {
         foreach (GameEntity timer in _timers)
         {
            timer.ReplaceEnemySpawnTimeLeft(timer.EnemySpawnTimeLeft - _time.DeltaTime);
            
            if (timer.EnemySpawnTimeLeft <= 0)
               timer.isReadyToSpawnNextEnemy = true;
         }
      }
   }
}