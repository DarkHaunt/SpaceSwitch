using System.Collections.Generic;
using Code.Gameplay.Common;
using Code.Gameplay.Features.Projectiles;
using Code.Gameplay.Features.Projectiles.Factories;
using Entitas;

namespace Code.Gameplay.Features.Enemy.Systems
{
   public class EnemyShootSystem : IExecuteSystem
   {
      private readonly ProjectileFactory _projectileFactory;
      private readonly List<GameEntity> _buffer = new(1);

      private readonly IGroup<GameEntity> _enemies;

      public EnemyShootSystem(GameContext context, ProjectileFactory projectileFactory)
      {
         _projectileFactory = projectileFactory;

         _enemies = context.GetGroup(GameMatcher
            .AllOf(
               GameMatcher.Enemy,
               GameMatcher.Id,
               GameMatcher.WorldPosition,
               GameMatcher.ColorType,
               GameMatcher.ShootDirection
            )
            .NoneOf(GameMatcher.ShootTimer));
      }

      public void Execute()
      {
         foreach (GameEntity enemy in _enemies.GetEntities(_buffer))
         {
            _projectileFactory.CreateProjectile(
               ProjectileTypeId.Simple_Enemy,
               enemy.Id,
               isPlayer: false,
               enemy.WorldPosition,
               enemy.ColorType,
               enemy.ShootDirection);

            enemy.AddShootTimer(GameplayConstants.EnemyShootDelay);
         }
      }
   }
}