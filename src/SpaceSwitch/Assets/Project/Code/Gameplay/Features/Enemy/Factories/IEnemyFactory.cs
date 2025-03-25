using UnityEngine;
using UnityEngine.Splines;

namespace Code.Gameplay.Features.Enemy
{
   public interface IEnemyFactory
   {
      GameEntity CreateEnemy(EnemyTypeId typeId, Spline spline);
   }
}