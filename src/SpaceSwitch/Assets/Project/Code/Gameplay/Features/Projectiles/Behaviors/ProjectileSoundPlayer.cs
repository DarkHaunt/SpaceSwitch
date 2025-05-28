using AnnulusGames.LucidTools.Audio;
using UnityEngine;

namespace Code.Gameplay.Features.Projectiles.Behaviors
{
   public class ProjectileSoundPlayer : MonoBehaviour
   {
      [SerializeField] private AudioClip _deathSound;
      
      public void PlayDeathSound() => 
         LucidAudio.PlaySE(_deathSound)
            .SetVolume(0.5f);
   }
}