using UnityEngine;

namespace Code.Gameplay.Windows.Configs
{
  [CreateAssetMenu(fileName = "Window Config", menuName = "Scriptable Objects/Window Config")]
  public class WindowConfig : ScriptableObject
  {
    [field: SerializeField] public WindowId Id { get; private set; }
    [field: SerializeField] public GameObject Prefab { get; private set; }
  }
}