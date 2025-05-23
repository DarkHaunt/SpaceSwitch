﻿using System;
using Code.Progress.Provider;
using Code.Progress.SaveLoad;
using UnityEngine;

namespace Code.Gameplay.Score
{
   public class ScoreService
   {
      public event Action OnScoreUpdated;
      
      private readonly IProgressProvider _progress;
      private readonly ISaveLoadService _saver;

      public int Score { get; private set; }

      public ScoreService(IProgressProvider progress, ISaveLoadService saver)
      {
         _progress = progress;
         _saver = saver;
      }


      public void AddScore(int score)
      {
         Score += score;
         OnScoreUpdated?.Invoke();
      }

      public void ClearCurrentScore()
      {
         Score = 0;
         OnScoreUpdated?.Invoke();
      }

      public void CheckScoreSave()
      {
         if (_progress.HighScore < Score)
         {
            _progress.ProgressData.HighScore = Score;
            _saver.SaveProgress();
         }
      }
   }
}