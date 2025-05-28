using AnnulusGames.LucidTools.Audio;
using UnityEngine;

namespace Code.Gameplay.Features.Enemy.Behaviors
{
   public class EnemySoundPlayer : MonoBehaviour
   {
      [SerializeField] private AudioClip _deathClip;
      [SerializeField] private AudioClip _shootClip;
      
      public void PlayDeathSound() =>
         LucidAudio.PlaySE(_deathClip)
            .SetVolume(0.5f);

      public void PlayShootSound() =>
         LucidAudio.PlaySE(_shootClip)
            .SetVolume(0.2f);
   }
}