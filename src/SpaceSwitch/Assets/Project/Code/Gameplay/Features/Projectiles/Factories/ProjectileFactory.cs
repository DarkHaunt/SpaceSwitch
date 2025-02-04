using System;
using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Gameplay.Features.ColorSwitch.StaticData;
using Code.Gameplay.StaticData;
using Code.Infrastructure.Identifiers;
using UnityEngine;

namespace Code.Gameplay.Features.Projectiles.Factories
{
   public class ProjectileFactory : IProjectileFactory
   {
      private readonly IIdentifierService _identifiers;
      private readonly IStaticDataService _staticDataService;

      public ProjectileFactory(IIdentifierService identifiers, IStaticDataService staticDataService)
      {
         _identifiers = identifiers;
         _staticDataService = staticDataService;
      }

      public GameEntity CreateProjectile(ProjectileTypeId typeId, Vector3 at, ColorType colorType, int producerId, Vector2 producerShootDirection)
      {
         GameEntity entity = typeId switch
         {
            ProjectileTypeId.Simple => CreateSimple(producerShootDirection),

            _ => throw new Exception($"Projectile with type id {typeId} does not exist")
         };
         
         entity = AddSharedComponents(entity, at, typeId, colorType, producerId);

         return entity;
      }

      private GameEntity AddSharedComponents(GameEntity enemy, Vector3 position, ProjectileTypeId typeId, ColorType colorType, int producerId)
      {
         enemy
            .AddId(_identifiers.Next())
            .AddProjectileTypeId(typeId)
            .AddProducerId(producerId)
            .AddWorldPosition(position)
            .AddColorType(colorType)
            
            .AddSelfDestructTimer(5f)
            
            .With(x => x.isProjectile = true)
            .With(x => x.isMoving = true)
            .With(x => x.isMovementAvailable = true)
            ;

         return enemy;
      }

      private GameEntity CreateSimple(Vector2 direction)
      {
         ProjectileConfig config = _staticDataService.GetProjectileConfigById(ProjectileTypeId.Simple);
         
         return CreateGameEntity.Empty()
               .AddDirection(direction)
               .AddDamage(config.Damage)
               .AddSpeed(config.Speed)
               .AddVelocity(Vector2.zero)
               .AddAssetReference(config.Prefab)
            ;
      }
   }
}