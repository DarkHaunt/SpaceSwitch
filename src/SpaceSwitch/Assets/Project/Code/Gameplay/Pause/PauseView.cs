using UnityEngine;
using UnityEngine.UI;

namespace Project.Code.Pause
{
   public class PauseView : MonoBehaviour
   {
      [field: SerializeField] public GameObject OpenedPanel { get; private set; }
      [field: SerializeField] public Button PauseButton { get; private set; }

      [field: Header("--- Buttons In Panel ---")]
      [field: SerializeField] public Button ResumeButton { get; private set; }
      [field: SerializeField] public Button RestartButton { get; private set; }
      [field: SerializeField] public Button MainMenuButton { get; private set; }
   }
}