using Code.Common.Extra;
using Entitas;

namespace Code.Gameplay.Features.Bounds
{
   [Game] public class BoundsComponent : IComponent { public Boundaries Value; }
   [Game] public class Bounded : IComponent { }
}