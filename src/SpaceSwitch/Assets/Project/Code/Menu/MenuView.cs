using UnityEngine;
using UnityEngine.UI;

namespace Code.Menu
{
   public class MenuView : MonoBehaviour
   {
      [field: SerializeField] public Button StartButton { get; private set; }
      [field: SerializeField] public Button QuitButton { get; private set; }
   }
}