namespace Code.Gameplay.Features.GameOver
{
   public static class GameOverSignalBus
   {
      public static event System.Action OnGameOver;
      public static event System.Action OnRestart;
      
      public static void NotifyGameOver() =>
         OnGameOver?.Invoke();
      
      public static void NotifyRestart() =>
         OnRestart?.Invoke();
   }
}