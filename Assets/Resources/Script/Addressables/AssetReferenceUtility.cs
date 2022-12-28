using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class AssetReferenceUtility : MonoBehaviour
{
    public AssetReference objectToLoad;
    public AssetReference accessoryObjectToLoad;

    private GameObject instantiatedObject;
    private GameObject instantiatedAccessoryObject;

    void Start()
    {
        Addressables.LoadAssetAsync<GameObject>(objectToLoad).Completed += ObjectLoadDone;
    }

    private void ObjectLoadDone(AsyncOperationHandle<GameObject> obj)
    {
        if(obj.Status == AsyncOperationStatus.Succeeded)
        {
            GameObject loadedObject = obj.Result;
            Debug.Log("오브젝트 로드 완료");

            instantiatedObject = Instantiate(loadedObject);
            Debug.Log("오브젝트 인스턴스화 완료");

            if(accessoryObjectToLoad != null)
            {
                accessoryObjectToLoad.InstantiateAsync(instantiatedObject.transform).Completed += op =>
                {
                    if (op.Status == AsyncOperationStatus.Succeeded)
                    {
                        instantiatedAccessoryObject = op.Result;
                        Debug.Log("Accesory Object 로드와 생성 완료");
                    }
                };
            }
        }
    }
}
