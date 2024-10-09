using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class AddressableObjectsLoader : MonoBehaviour
{
    public static AddressableObjectsLoader Instance { get; private set; }
    
    [SerializeField] private AssetReferenceSprite[] _assetReferenceSprites;
    [SerializeField] private SpriteRenderer[] _spriteRenderers;

    private int _spriteRendererIndex;

    private void Awake()
    {
        Instance = this;
    }

    public void LoadSprites()
    {
        _spriteRendererIndex = 0;
        
        foreach (var assetReferenceSprite in _assetReferenceSprites)
        {
            assetReferenceSprite.LoadAssetAsync<Sprite>().Completed += OnLoadAssetAsyncCompleted;
        }
    }

    private void OnLoadAssetAsyncCompleted(AsyncOperationHandle<Sprite> asyncOperationHandle)
    {
        if (asyncOperationHandle.Status == AsyncOperationStatus.Succeeded)
        {
            _spriteRenderers[_spriteRendererIndex++].sprite = asyncOperationHandle.Result;
        }
        else
        {
            Debug.Log("Failed to load!");
        }
    }
}