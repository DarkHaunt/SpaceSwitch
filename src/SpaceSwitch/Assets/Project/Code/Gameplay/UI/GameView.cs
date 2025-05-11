using TMPro;
using UnityEngine;

namespace Code.Gameplay.UI
{
   public class GameView : MonoBehaviour
   {
      [field: SerializeField] public TextMeshProUGUI Score { get; private set; }
   }
}