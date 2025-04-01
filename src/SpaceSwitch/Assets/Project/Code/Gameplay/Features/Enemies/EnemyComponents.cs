using Entitas;

namespace Code.Gameplay.Features.Enemy
{
   public class EnemyComponents
   {
      [Game] public class Enemy : IComponent { }
      [Game] public class EnemyTypeIdComponent : IComponent { public EnemyTypeId Value; }
   }
}