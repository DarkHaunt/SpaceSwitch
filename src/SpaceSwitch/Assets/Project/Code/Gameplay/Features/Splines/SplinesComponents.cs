using Entitas;
using UnityEngine.Splines;

namespace Code.Gameplay.Features.Splines
{
   [Game] public class MovingSpline : IComponent { }
   [Game] public class ReachedSplineEnd : IComponent { }
   [Game] public class SplineTPosition : IComponent { public float Value; }
   [Game] public class SplineComponent : IComponent { public Spline Value; }
}