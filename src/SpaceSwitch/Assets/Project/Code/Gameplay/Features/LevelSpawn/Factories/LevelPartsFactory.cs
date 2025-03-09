using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Gameplay.Features.Scrolling.Behaviors;
using Code.Gameplay.Features.Scrolling.StaticData;
using Code.Infrastructure.Identifiers;
using Code.Infrastructure.View;
using UnityEngine;

namespace Code.Gameplay.Features.Scrolling.Factories
{
   public class LevelPartsFactory
   {
      private readonly IIdentifierService _identifiers;

      public LevelPartsFactory(IIdentifierService identifiers)
      {
         _identifiers = identifiers;
      }
      
      public LevelPart CreateLevelPart(LevelPart prefab, Transform parent, Vector3 position = default) => 
         Object.Instantiate(prefab, position, Quaternion.identity, parent);

      public GameEntity CreateLevelPartEntity(LevelPart nextPart, LevelsConfig config)
      {
         EntityBehaviour view = nextPart.View;
         
         GameEntity entity = CreateGameEntity.Empty()
            .AddId(_identifiers.Next())
            .AddLevelPart(nextPart)
            .AddWorldPosition(nextPart.transform.position)

            .AddSpeed(config.LevelMoveSpeed)
            .AddVelocity(Vector2.zero)
            .AddDirection(Vector2.down)
            .AddClampedZ(LevelSpawnConstants.CommonZPos)
            
            .With(x => x.isMoving = true)
            .With(x => x.isMovementAvailable = true)
            ;
         
         view.SetEntity(entity);
         
         return entity;
      }
   }
}