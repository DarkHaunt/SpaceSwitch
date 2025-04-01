using System;
using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Infrastructure.Identifiers;
using UnityEngine;
using UnityEngine.Splines;

namespace Code.Gameplay.Features.Enemy
{
   public class EnemyFactory
   {
      private readonly IIdentifierService _identifiers;

      public EnemyFactory(IIdentifierService identifiers)
      {
         _identifiers = identifiers;
      }

      public GameEntity CreateEnemy(EnemyTypeId typeId, Spline spline)
      {
         GameEntity entity = typeId switch
         {
            EnemyTypeId.Simple => CreateSimple(),

            _ => throw new Exception($"Enemy with type id {typeId} does not exist")
         };
         
         entity = AddSharedComponents(entity, spline, typeId);

         return entity;
      }

      private GameEntity AddSharedComponents(GameEntity enemy, Spline spline, EnemyTypeId typeId)
      {
         enemy
            .AddId(_identifiers.Next())
            .AddEnemyTypeId(typeId)
            .AddSpline(spline)
            
            .With(x => x.isEnemy = true)
            .With(x => x.isMovingSpline = true)
            
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