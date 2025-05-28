using AnnulusGames.LucidTools.Audio;
using UnityEngine;

namespace Code.Gameplay.Features.Player.Behaviors
{
   public class PlayerSoundPlayer : MonoBehaviour
   {
      [SerializeField] private AudioClip _shootSound;
      [SerializeField] private AudioClip _deathSound;
      [SerializeField] private AudioClip _ambientSound;
      [SerializeField] private AudioClip _colorSwitchSound;
      
      private AudioPlayer _ambient;

      public void PlayShootSound() =>
         LucidAudio.PlaySE(_shootSound)
            .SetVolume(0.2f);
      
      public void PlayDeathSound() =>
         LucidAudio.PlaySE(_deathSound)
            .SetVolume(2f);
      
      public void PlayColorSwitchSound() =>
         LucidAudio.PlaySE(_colorSwitchSound)
            .SetVolume(0.5f);
      
      public void PlayAmbientSound()
      {
         _ambient = LucidAudio.PlaySE(_ambientSound)
            .SetLoop(true)
            .SetVolume(0.5f);
      }

      public void StopAmbientSound() =>
         _ambient?.Stop();
   }
}