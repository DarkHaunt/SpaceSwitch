using Code.Infrastructure.Systems;

namespace Project.Code.Gameplay.Features.Cameras
{
   public sealed class CameraFeature : Feature
   {
      public CameraFeature(ISystemFactory systems)
      {
         Add(systems.Create<CameraClampZSystem>());
      }
   }
}