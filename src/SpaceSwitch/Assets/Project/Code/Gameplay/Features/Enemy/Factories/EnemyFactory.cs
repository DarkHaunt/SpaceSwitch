using System;
using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Infrastructure.Identifiers;
using UnityEngine;

namespace Code.Gameplay.Features.Enemy
{
   public class EnemyFactory : IEnemyFactory
   {
      private readonly IIdentifierService _identifiers;

      public EnemyFactory(IIdentifierService identifiers)
      {
         _identifiers = identifiers;
      }

      public GameEntity CreateEnemy(EnemyTypeId typeId, Vector3 at)
      {
         GameEntity entity = typeId switch
         {
            EnemyTypeId.Simple => CreateSimple(),

            _ => throw new Exception($"Enemy with type id {typeId} does not exist")
         };
         
         entity = AddSharedComponents(entity, at, typeId);

         return entity;
      }

      private GameEntity AddSharedComponents(GameEntity enemy, Vector3 position, EnemyTypeId typeId)
      {
         enemy
            .AddId(_identifiers.Next())
            .With(x => x.isEnemy = true)
            .AddEnemyTypeId(typeId)
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