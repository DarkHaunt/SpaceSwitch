using System.Collections.Generic;
using Code.Gameplay.Features.Scrolling.Behaviors;
using Code.Gameplay.Features.Scrolling.StaticData;
using Code.Gameplay.StaticData;

namespace Code.Gameplay.Features.Scrolling.Services
{
   public class LevelPartProvider
   {
      private List<LevelPart> _availableParts;
      private Queue<LevelPart> _prefabsSpawnQueue;
      
      public IEnumerator<LevelPart> AllAvailableParts => _availableParts.GetEnumerator();

      public void Setup(LevelsConfig config)
      {
         _availableParts = new List<LevelPart>(config.LevelParts);
         _prefabsSpawnQueue = new Queue<LevelPart>(config.LevelParts);
      }

      public LevelPart GetNextPart()
      {
         LevelPart part = _prefabsSpawnQueue.Dequeue();
         
         if(_prefabsSpawnQueue.Count == 0)
            UpdatePartProvided();

         return part;
      }

      private void UpdatePartProvided()
      {
         _prefabsSpawnQueue.Clear();
         _prefabsSpawnQueue = new Queue<LevelPart>(_availableParts);
      }
   }
}