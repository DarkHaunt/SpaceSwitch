using System.Collections.Generic;
using System.Linq;
using Code.Gameplay.Features.Scrolling.Behaviors;
using Code.Gameplay.Features.Scrolling.Factories;
using Code.Gameplay.Features.Scrolling.StaticData;
using Code.Gameplay.StaticData;
using UnityEngine;

namespace Code.Gameplay.Features.Scrolling.Services
{
   public class LevelPartsHandleService
   {
      private const int PoolSize = 2;

      private readonly LevelPartProvider _partProvider;
      private readonly IStaticDataService _staticData;
      private readonly LevelPartsFactory _factory;

      private readonly Dictionary<int, List<LevelPart>> _partsById = new();
      public LevelPart LastCreatedPart { get; private set; }

      private Transform _parent;
      private LevelsConfig _config;

      public LevelPartsHandleService(LevelPartsFactory factory, LevelPartProvider partProvider, IStaticDataService staticData)
      {
         _factory = factory;
         _partProvider = partProvider;
         _staticData = staticData;
      }


      public void Setup()
      {
         _parent = new GameObject("[LevelParts]").transform;

         _config = _staticData.LevelsConfig;
         _partProvider.Setup(_config);

        // FillPools();
         InitialSpawnParts();
      }

      public GameEntity SetNextPart(LevelPart lastLevelPart)
      {
         LevelPart nextPartPrefab = _partProvider.GetNextPart();
         LevelPart nextPart = GetNextPart(nextPartPrefab);

         PlacePartToLastPartEnd(lastLevelPart, nextPart);

         GameEntity entity = _factory.CreateLevelPartEntity(nextPart, _config);
         return entity;
      }

      private void PlacePartToLastPartEnd(LevelPart lastLevelPart, LevelPart nextPart)
      {
         Vector3 positionToPlace = lastLevelPart.TopRight - nextPart.LeftBottom;
         positionToPlace.x = lastLevelPart.transform.position.x;

         nextPart.transform.position = positionToPlace;

         AdjustPartPositionByZ(nextPart);
      }

      public void SetLevelPartToPool(LevelPart levelPart)
      {
         // TODO: Add pooling maybe
         return;
         _partsById[levelPart.ID].Add(levelPart);

         levelPart.transform.position = Vector3.zero;
         levelPart.gameObject.SetActive(false);
      }

      private void InitialSpawnParts()
      {
         // Spawn first part
         LevelPart nextPartPrefab = _partProvider.GetNextPart();
         LevelPart nextPart = GetNextPart(nextPartPrefab);

         _factory.CreateLevelPartEntity(nextPart, _config);

         AdjustPartPositionByZ(nextPart);
      }

      private LevelPart GetNextPart(LevelPart prefab)
      {
         /*if (_partsById.TryGetValue(prefab.ID, out var parts) && parts.Count > 0)
         {
            parts.Remove(LastCreatedPart);

            LastCreatedPart = parts.First();
            LastCreatedPart.gameObject.SetActive(true);
         }
         else
         {
         }*/
            LastCreatedPart = _factory.CreateLevelPart(prefab, _parent);


         return LastCreatedPart;
      }

      /*private void FillPools()
      {
         foreach (LevelPart prefab in _config.LevelParts)
         {
            if (!_partsById.ContainsKey(prefab.ID))
            {
               _partsById.Add(prefab.ID, new List<LevelPart>(PoolSize));

               for (int i = 0; i < PoolSize; i++)
               {
                  LevelPart part = _factory.CreateLevelPart(prefab, _parent);
                  SetLevelPartToPool(part);
               }
            }
         }
      }*/

      private static void AdjustPartPositionByZ(LevelPart nextPart)
      {
         Vector3 adjustedPosition = nextPart.transform.position;
         adjustedPosition.z = LevelSpawnConstants.CommonZPos;

         nextPart.transform.position = adjustedPosition;
      }
   }
}