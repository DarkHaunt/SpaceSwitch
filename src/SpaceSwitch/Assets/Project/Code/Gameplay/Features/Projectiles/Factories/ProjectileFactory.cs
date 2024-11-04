using System;
using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Gameplay.Features.Enemy;
using Code.Infrastructure.Identifiers;
using UnityEngine;

namespace Code.Gameplay.Features.Projectiles.Factories
{
   public class ProjectileFactory : IProjectileFactory
   {
      private readonly IIdentifierService _identifiers;

      public ProjectileFactory(IIdentifierService identifiers)
      {
         _identifiers = identifiers;
      }

      public GameEntity CreateProjectile(ProjectileTypeId typeId, Vector3 at)
      {
         GameEntity entity = typeId switch
         {
            ProjectileTypeId.Simple => CreateSimple(),

            _ => throw new Exception($"Projectile with type id {typeId} does not exist")
         };
         
         entity = AddSharedComponents(entity, at, typeId);

         return entity;
      }

      private GameEntity AddSharedComponents(GameEntity enemy, Vector3 position, ProjectileTypeId typeId)
      {
         enemy
            .AddId(_identifiers.Next())
            .With(x => x.isEnemy = true)
            .AddProjectileTypeId(typeId)
            .AddWorldPosition(position)
            ;

         return enemy;
      }

      private GameEntity CreateSimple()
      {
         return CreateGameEntity.Empty()
            
            ;
      }
   }
}