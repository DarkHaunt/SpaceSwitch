using Code.Gameplay.Features.Projectiles.Behaviors;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Projectiles
{
   [Game] public class Projectile : IComponent { }
   [Game] public class PlayerProjectile : IComponent { }
   [Game] public class EnemyProjectile : IComponent { }
   [Game] public class ProjectileTypeIdComponent : IComponent { public ProjectileTypeId Value; }
   [Game] public class ShootDirection : IComponent { public Vector2 Value; }
   [Game] public class ProjectileAnimatorComponent : IComponent { public ProjectileAnimator Value; }
}