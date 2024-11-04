using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Code.Infrastructure.AssetManagement
{
  public interface IAssetProvider
  {
    UniTask InitializeAsync();
    UniTask<TAsset> Load<TAsset>(AssetReference assetReference) where TAsset : MonoBehaviour;
    UniTask<T> Load<T>(string key) where T : class;
    UniTask<T> LoadAndGetComponent<T>(string key) where T : MonoBehaviour;
    UniTask<T[]> LoadAll<T>(List<string> keys) where T : class;
    UniTask<List<string>> FetchAssetKeysByLabel<T>(string label);
    UniTask WarmupAssetsByLabel(string label);
    UniTask ReleaseAssetsByLabel(string label);

    T LoadFromResources<T>(string path) where T : Object // TODO: maybe own class for it
    ;

    UniTask<T[]> LoadAllByLabel<T>(string label) where T : class;
  }
}