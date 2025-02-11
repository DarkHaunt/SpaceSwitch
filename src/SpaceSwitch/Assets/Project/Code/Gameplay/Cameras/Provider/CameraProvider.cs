using UnityEngine;

namespace Code.Gameplay.Cameras.Provider
{
  public class CameraProvider : ICameraProvider
  {
    public Camera MainCamera { get; private set; }

    public float WorldScreenHeight { get; private set; }
    public float WorldScreenWidth { get; private set; }
    
    public Vector2 WorldLeftBottomBoundPosition { get; private set; }
    public Vector2 WorldRightTopBoundPosition { get; private set; }
    

    public void SetMainCamera(Camera camera)
    {
      MainCamera = camera;

      RefreshBoundaries();
    }

    private void RefreshBoundaries()
    {
      WorldLeftBottomBoundPosition = MainCamera.ViewportToWorldPoint(new Vector3(0, 0, MainCamera.nearClipPlane));
      WorldRightTopBoundPosition = MainCamera.ViewportToWorldPoint(new Vector3(1, 1, MainCamera.nearClipPlane));
      
      WorldScreenWidth = WorldRightTopBoundPosition.x - WorldLeftBottomBoundPosition.x;
      WorldScreenHeight = WorldRightTopBoundPosition.y - WorldLeftBottomBoundPosition.y;
    }
  }
}