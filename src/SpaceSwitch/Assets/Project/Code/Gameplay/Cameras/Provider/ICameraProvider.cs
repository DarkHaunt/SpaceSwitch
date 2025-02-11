using UnityEngine;

namespace Code.Gameplay.Cameras.Provider
{
  public interface ICameraProvider
  {
    Camera MainCamera { get; }
    float WorldScreenHeight { get; }
    float WorldScreenWidth { get; }
    Vector2 WorldLeftBottomBoundPosition { get; }
    Vector2 WorldRightTopBoundPosition { get; }
    void SetMainCamera(Camera camera);
  }
}