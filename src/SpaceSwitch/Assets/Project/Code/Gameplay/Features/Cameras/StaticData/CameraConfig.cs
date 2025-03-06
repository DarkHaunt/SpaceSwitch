using UnityEngine;

namespace Project.Code.Gameplay.Features.Cameras
{
   [CreateAssetMenu(fileName = "Camera Config", menuName = "Scriptable Objects/Camera Config")]
   public class CameraConfig : ScriptableObject
   {
      [field: SerializeField] public float MoveSpeed { get; private set; }
   }
}

