using Code.Gameplay.Features.ColorSwitch.Behaviors;
using Code.Gameplay.Features.ColorSwitch.StaticData;
using Entitas;

namespace Code.Gameplay.Features.ColorSwitch
{
   [Game] public class ColorTypeComponent : IComponent { public ColorType Value; }
   [Game] public class ColorSwitchRequest : IComponent { public ColorType Value; }
   [Game] public class ColorSwitchAnimatorComponent : IComponent { public ColorSwitchAnimator Value; }
}