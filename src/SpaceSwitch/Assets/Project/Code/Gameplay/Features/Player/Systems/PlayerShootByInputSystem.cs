﻿using System.Collections.Generic;
using Code.Gameplay.Common;
using Code.Gameplay.Features.Projectiles;
using Code.Gameplay.Features.Projectiles.Factories;
using Entitas;
using UnityEngine;

namespace Project.Code.Gameplay.Features.Player.Systems
{
   public sealed class PlayerShootByInputSystem : IExecuteSystem
   {
      private readonly IProjectileFactory _projectileFactory;
      private readonly List<GameEntity> _buffer = new (1);

      private readonly IGroup<GameEntity> _players;
      private readonly IGroup<InputEntity> _inputs;

      public PlayerShootByInputSystem(GameContext context, InputContext inputContext, IProjectileFactory projectileFactory)
      {
         _projectileFactory = projectileFactory;
         _inputs = inputContext.GetGroup(InputMatcher.Input);

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
         foreach (InputEntity input in _inputs)
         foreach (GameEntity player in _players.GetEntities(_buffer))
         {
            if (input.isAttackRequested)
            {
               Debug.Log($"<color=white>Shoot</color>");
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
}