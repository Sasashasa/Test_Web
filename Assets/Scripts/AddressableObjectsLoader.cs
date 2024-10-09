using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class AddressableObjectsLoader : MonoBehaviour
{
    public static AddressableObjectsLoader Instance { get; private set; }
    
    [SerializeField] private AssetReferenceSprite[] _assetReferenceSprites;
    [SerializeField] private SpriteRenderer[] _spriteRenderers;

    private void Awake()
    {
        Instance = this;
    }

    public void LoadSprites()
    {
        for (int i = 0; i < _assetReferenceSprites.Length; i++)
        {
            int j = i;
            
            _assetReferenceSprites[i].LoadAssetAsync<Sprite>().Completed +=
                asyncOperationHandle =>
                {
                    if (asyncOperationHandle.Status == AsyncOperationStatus.Succeeded)
                    {
                        _spriteRenderers[j].sprite = asyncOperationHandle.Result;
                    }
                    else
                    {
                        Debug.Log("Failed to load!");
                    }
                };
        }
    }
}