using UnityEngine;

namespace Code.Gameplay.Features.Projectiles.Factories
{
   public interface IProjectileFactory
   {
      GameEntity CreateProjectile(ProjectileTypeId typeId, Vector3 at);
   }
}