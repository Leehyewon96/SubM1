using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class FilteredReferences : MonoBehaviour
{
    [Serializable]
    public class AssetReferenceMaterial : AssetReferenceT<Material>
    {
        public AssetReferenceMaterial(string guid) : base(guid) { }
    }

    private SpriteRenderer spriteRenderer;
    public AssetReferenceMaterial materialReference;
    public AssetReferenceSprite spriteReference;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void OnLoadSprite()
    {
        spriteReference.LoadAssetAsync().Completed += SpriteLoaded;
    }

    public void OnLoadMaterial()
    {
        materialReference.LoadAssetAsync().Completed += MaterialLoaded;
    }

    public void OnUnLoadSprite()
    {
        spriteReference.ReleaseAsset();
    }

    public void OnUnLoadMaterial()
    {
        materialReference.ReleaseAsset();
    }

    private void SpriteLoaded(AsyncOperationHandle<Sprite> obj)
    {
        switch(obj.Status)
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

    private void MaterialLoaded(AsyncOperationHandle<Material> obj)
    {
        switch(obj.Status)
        {
            case AsyncOperationStatus.Succeeded:
                spriteRenderer.material = obj.Result;
                break;
            case AsyncOperationStatus.Failed:
                Debug.Log("머테리얼 로드 실패");
                break;
            default:
                break;
        }
    }
}