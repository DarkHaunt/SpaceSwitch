using Code.Gameplay.Features.Enemy.Behaviors;
using Entitas;

namespace Code.Gameplay.Features.Enemy
{
   public class EnemyComponents
   {
      [Game] public class Enemy : IComponent { }
      [Game] public class EnemyTypeIdComponent : IComponent { public EnemyTypeId Value; }
      [Game] public class Score : IComponent { public int Value; }
      [Game] public class EnemyAnimatorComponent : IComponent { public EnemyAnimator Value; }
   }
}