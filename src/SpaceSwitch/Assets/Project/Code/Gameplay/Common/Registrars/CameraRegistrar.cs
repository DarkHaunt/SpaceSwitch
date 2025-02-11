using Code.Infrastructure.View.Registrars;
using UnityEngine;

namespace Code.Gameplay.Common.Registrars
{
   public class CameraRegistrar : EntityComponentRegistrar
   {
      public Camera Camera;

      public override void RegisterComponents()
      {
         Entity.AddCamera(Camera);
      }

      public override void UnregisterComponents()
      {
         if (Entity.hasCamera)
            Entity.RemoveCamera();
      }
   }
}