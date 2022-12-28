using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class AdressableSpriteLoader : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    public bool isUseAddress;

    public AssetReferenceSprite newSprite;
    public string newSpriteAddress;
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        spriteRenderer.sprite = null;

        if(isUseAddress == true)
        {
            Addressables.LoadAssetAsync<Sprite>(newSpriteAddress).Completed += SpriteLoaded;
        }
        else
        {
            newSprite.LoadAssetAsync().Completed += SpriteLoaded;
        }
    }

    private void SpriteLoaded(AsyncOperationHandle<Sprite> obj)
    {
        switch (obj.Status)
        {
            case AsyncOperationStatus.Succeeded:
                spriteRenderer.sprite = obj.Result;
                break;
            case AsyncOperationStatus.Failed:
                Debug.Log("스프라이트 로드 실패");
                break;
            default:
                break;
        }
    }
}
