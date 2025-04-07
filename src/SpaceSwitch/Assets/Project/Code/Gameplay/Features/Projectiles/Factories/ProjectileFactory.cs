using System;
using System.Collections.Generic;
using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Gameplay.Features.ColorSwitch.StaticData;
using Code.Gameplay.StaticData;
using Code.Infrastructure.Identifiers;
using UnityEngine;

namespace Code.Gameplay.Features.Projectiles.Factories
{
   public class ProjectileFactory
   {
      private const int TargetBufferSize = 16;

      private readonly IIdentifierService _identifiers;
      private readonly IStaticDataService _staticDataService;

      public ProjectileFactory(IIdentifierService identifiers, IStaticDataService staticDataService)
      {
         _identifiers = identifiers;
         _staticDataService = staticDataService;
      }

      public GameEntity CreateProjectile(ProjectileTypeId typeId, int producerId, bool isPlayer, Vector3 at, ColorType colorType,
         Vector2 producerShootDirection)
      {
         GameEntity entity = typeId switch
         {
            ProjectileTypeId.Simple => CreateSimple(producerShootDirection),

            _ => throw new Exception($"Projectile with type id {typeId} does not exist")
         };

         entity = AddSharedComponents(entity, at, typeId, colorType, producerId);

         if (isPlayer)
         {
            entity
               .AddLayerMask(CollisionLayer.Enemy.AsMask())
               .With(x => x.isPlayerProjectile = true);
         }
         else
         {
            entity
               .AddLayerMask(CollisionLayer.Player.AsMask())
               .With(x => x.isEnemyProjectile = true);
         }

         return entity;
      }

      private GameEntity AddSharedComponents(GameEntity projectile, Vector3 position, ProjectileTypeId typeId, ColorType colorType, int producerId)
      {
         projectile
            .AddId(_identifiers.Next())
            .AddProjectileTypeId(typeId)
            .AddProducerId(producerId)
            .AddWorldPosition(position)
            .AddColorType(colorType)
            
            .AddTargetBuffer(new List<int>(TargetBufferSize))
            .AddProcessedTargets(new List<int>(TargetBufferSize))
            .AddSelfDestructTimer(5f)
            
            .With(x => x.isProjectile = true)
            .With(x => x.isMoving = true)
            .With(x => x.isMovementAvailable = true)
            .With(x => x.isCollectingTargetsContinuously = true)
            .With(x => x.isReadyToCollectTargets = true)
            ;

         return projectile;
      }

      private GameEntity CreateSimple(Vector2 direction)
      {
         ProjectileConfig config = _staticDataService.GetProjectileConfigById(ProjectileTypeId.Simple);

         return CreateGameEntity.Empty()
               .AddTargetLimit(1)
               .AddDirection(direction)
               .AddDamage(config.Damage)
               .AddRadius(config.ContactRadius)
               .AddSpeed(config.Speed)
               .AddVelocity(Vector2.zero)
               .AddViewPrefab(config.Prefab)
               .With(x => x.AddEffectSetups(config.Effects), when: !config.Effects.IsNullOrEmpty())
            ;
      }
   }
}