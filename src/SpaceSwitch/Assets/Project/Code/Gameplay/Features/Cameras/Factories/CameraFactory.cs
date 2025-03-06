using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Gameplay.Cameras.Provider;
using Code.Infrastructure.Identifiers;
using Code.Infrastructure.View;
using UnityEngine;

namespace Project.Code.Gameplay.Features.Cameras.Factories
{
   public class CameraFactory
   {
      private readonly ICameraProvider _cameraProvider;
      private readonly IIdentifierService _identifiers;


      public CameraFactory(ICameraProvider cameraProvider, IIdentifierService identifiers)
      {
         _cameraProvider = cameraProvider;
         _identifiers = identifiers;
      }

      public GameEntity CreateCamera(CameraConfig config)
      {
         var cameraEntity = _cameraProvider.MainCamera.GetComponent<EntityBehaviour>();
         
         GameEntity entity = CreateGameEntity.Empty()
               .AddId(_identifiers.Next())
               .AddSpeed(config.MoveSpeed)
               
               .AddWorldPosition(Vector3.zero)
               .AddDirection(Vector2.up)
               .AddVelocity(Vector2.zero)
               
               .With(x => x.isMovementAvailable = true)
               .With(x => x.isMoving = true)
               .With(x => x.isCamera = true)
            ;
         
         cameraEntity.SetEntity(entity);
         return entity;
      }
   }
}