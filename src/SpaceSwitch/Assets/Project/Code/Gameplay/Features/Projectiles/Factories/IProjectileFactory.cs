using Code.Gameplay.Features.ColorSwitch.StaticData;
using UnityEngine;

namespace Code.Gameplay.Features.Projectiles.Factories
{
   public interface IProjectileFactory
   {
      GameEntity CreateProjectile(ProjectileTypeId typeId, Vector3 at, ColorType colorType, int producerId, Vector2 producerShootDirection);
   }
}