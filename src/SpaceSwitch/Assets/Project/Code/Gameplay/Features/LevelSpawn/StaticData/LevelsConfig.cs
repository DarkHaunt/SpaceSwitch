using System.Collections.Generic;
using Code.Gameplay.Features.Scrolling.Behaviors;
using UnityEngine;

namespace Code.Gameplay.Features.Scrolling.StaticData
{
   [CreateAssetMenu(fileName = "Levels Config", menuName = "Scriptable Objects/Levels Config")]
   public class LevelsConfig : ScriptableObject
   {
      [field: SerializeField] public float LevelMoveSpeed { get; private set; }
      
      [field: Space]
      [field: SerializeField] public List<LevelPart> LevelParts { get; private set; }
   }
}