using UnityEngine;

namespace Code.Gameplay.Features.Enemy
{
   public interface IEnemyFactory
   {
      GameEntity CreateEnemy(EnemyTypeId typeId, Vector3 at);
   }
}