using System.Collections.Generic;
using Code.Gameplay.Cameras.Provider;
using Code.Gameplay.Features.Scrolling.Services;
using Entitas;

namespace Code.Gameplay.Features.Scrolling.Systems
{
   public sealed class HandleLevelPartsSwitchSystem : IExecuteSystem
   {
      private readonly List<GameEntity> _buffer = new (6);
      
      private readonly ICameraProvider _cameraProvider;
      private readonly LevelPartsHandleService _levelPartsHandleService;
      private readonly IGroup<GameEntity> _levelParts;

      public HandleLevelPartsSwitchSystem(GameContext context, ICameraProvider cameraProvider, LevelPartsHandleService levelPartsHandleService)
      {
         _cameraProvider = cameraProvider;
         _levelPartsHandleService = levelPartsHandleService;
         _levelParts = context.GetGroup(GameMatcher
            .AllOf(
               GameMatcher.LevelPart,
               GameMatcher.WorldPosition
            ));
      }

      public void Execute()
      {
         foreach (GameEntity levelPart in _levelParts.GetEntities(_buffer))
         {
            if (levelPart.LevelPart.TopRight.y < _cameraProvider.WorldLeftBottomBoundPosition.y)
            {
               levelPart.isDestructed = true;     
               _levelPartsHandleService.SetLevelPartToPool(levelPart.LevelPart);
            }

            if(_levelPartsHandleService.LastCreatedPart != levelPart.LevelPart) 
               continue;
            
            if (levelPart.LevelPart.TopRight.y < _cameraProvider.WorldRightTopBoundPosition.y)
               _levelPartsHandleService.SetNextPart(levelPart.LevelPart);
         }
      }
   }
}