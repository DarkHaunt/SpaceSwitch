using Code.Gameplay.Features.Splines.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Splines
{
   public sealed class SplineFeature : Feature
   {
      public SplineFeature(ISystemFactory systems)
      {
         Add(systems.Create<EvaluateThroughSplineSystem>());
         
         Add(systems.Create<MoveBySplineSystem>());
         Add(systems.Create<MarkReachedSplineMoversSystem>());
      }
   }
}