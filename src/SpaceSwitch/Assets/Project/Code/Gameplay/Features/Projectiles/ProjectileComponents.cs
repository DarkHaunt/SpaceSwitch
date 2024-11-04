using Entitas;

namespace Code.Gameplay.Features.Projectiles
{
   [Game] public class Projectile : IComponent { }
   [Game] public class ProjectileTypeIdComponent : IComponent { public ProjectileTypeId Value; }
}