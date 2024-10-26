using Code.Gameplay.StaticData;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Code.Gameplay.Windows
{
  public class WindowFactory : IWindowFactory
  {
    private readonly IStaticDataService _staticData;
    private readonly IObjectResolver _resolver;
    private RectTransform _uiRoot;

    public WindowFactory(IStaticDataService staticData, IObjectResolver resolver)
    {
      _staticData = staticData;
      _resolver = resolver;
    }

    public void SetUIRoot(RectTransform uiRoot) =>
      _uiRoot = uiRoot;

    public BaseWindow CreateWindow(WindowId windowId)
    {
      var prefab = PrefabFor(windowId)
        .GetComponent<BaseWindow>();
      
      return _resolver.Instantiate(prefab, _uiRoot);
    }

    private GameObject PrefabFor(WindowId id) =>
      _staticData.GetWindowPrefab(id);
  }
}