using System.Collections.Generic;
using Code.Gameplay.Common;
using Code.Gameplay.Features.Projectiles;
using Code.Gameplay.Features.Projectiles.Factories;
using Entitas;
using UnityEngine;

namespace Project.Code.Gameplay.Features.Player.Systems
{
   public sealed class PlayerLoopShootSystem : IExecuteSystem
   {
      private readonly IProjectileFactory _projectileFactory;
      private readonly List<GameEntity> _buffer = new(1);

      private readonly IGroup<GameEntity> _players;

      public PlayerLoopShootSystem(GameContext context, IProjectileFactory projectileFactory)
      {
         _projectileFactory = projectileFactory;

         _players = context.GetGroup(GameMatcher
            .AllOf(
               GameMatcher.Player,
               GameMatcher.Id,
               GameMatcher.WorldPosition,
               GameMatcher.ColorType,
               GameMatcher.ShootDirection
            )
            .NoneOf(GameMatcher.ShootTimer));
      }

      public void Execute()
      {
         foreach (GameEntity player in _players.GetEntities(_buffer))
         {
            _projectileFactory.CreateProjectile(
               ProjectileTypeId.Simple,
               player.WorldPosition,
               player.ColorType,
               player.Id,
               player.ShootDirection);

            player.AddShootTimer(GameplayConstants.PlayerShootDelay);
         }
      }
   }
}