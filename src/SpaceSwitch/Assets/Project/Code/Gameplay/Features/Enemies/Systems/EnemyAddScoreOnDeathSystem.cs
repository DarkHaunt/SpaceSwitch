using Code.Gameplay.Score;
using Entitas;

namespace Code.Gameplay.Features.Enemy.Systems
{
   public sealed class EnemyAddScoreOnDeathSystem : IExecuteSystem
   {
      private readonly IGroup<GameEntity> _group;
      private readonly ScoreService _scoreService;

      public EnemyAddScoreOnDeathSystem(GameContext context, ScoreService scoreService)
      {
         _scoreService = scoreService;
         _group = context.GetGroup(GameMatcher
            .AllOf(
               GameMatcher.Enemy,
               GameMatcher.Dead,
               GameMatcher.ProcessingDeath,
               GameMatcher.Score
            ));
      }

      public void Execute()
      {
         foreach (GameEntity entity in _group)
            _scoreService.AddScore(entity.Score);
      }
   }
}