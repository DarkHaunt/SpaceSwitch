using Code.Gameplay.Features.Player.Behaviors;
using Entitas;

namespace Code.Gameplay.Features.Player
{
   [Game] public class Player : IComponent { }
   [Game] public class PlayerAnimatorComponent : IComponent { public PlayerAnimator Value; }
   [Game] public class PlayerSoundPlayerComponent : IComponent { public PlayerSoundPlayer Value; }
}

