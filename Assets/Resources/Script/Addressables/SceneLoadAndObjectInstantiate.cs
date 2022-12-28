using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;

public class SceneLoadAndObjectInstantiate : MonoBehaviour
{
    public AssetReference addSceneReference;
    public AssetReferenceGameObject sphereReference;

    bool isSphereLoad = false;
    SceneInstance m_LoadedScene;
    List<GameObject> sphereGameObjects = new List<GameObject>();

    public void OnSceneAction()
    {
        if(m_LoadedScene.Scene.name == null)
        {
            Addressables.LoadSceneAsync(addSceneReference, LoadSceneMode.Additive).Completed += OnSceneLoaded;
        }
        else
        {
            Addressables.UnloadSceneAsync(m_LoadedScene).Completed += OnSceneUnloaded;
        }
    }

    private void OnSceneUnloaded(AsyncOperationHandle<SceneInstance> obj)
    {
        switch(obj.Status)
        {
            case AsyncOperationStatus.Succeeded:
                m_LoadedScene = new SceneInstance();
                break;
            case AsyncOperationStatus.Failed:
                Debug.Log("씬 언로드 실패: " + addSceneReference.AssetGUID);
                break;
            default:
                break;
        }
    }

    private void OnSceneLoaded(AsyncOperationHandle<SceneInstance> obj)
    {
        switch(obj.Status)
        {
            case AsyncOperationStatus.Succeeded:
                m_LoadedScene = obj.Result;
                break;
            case AsyncOperationStatus.Failed:
                Debug.Log("씬 로드 실패: " + addSceneReference.AssetGUID);
                break;
            default:
                break;
        }
    }

    public void OnSphereAction()
    {
        if(isSphereLoad == false)
        {
            sphereReference.LoadAssetAsync().Completed += OnSphereLoaded;
            isSphereLoad = true;
        }
        else
        {
            sphereReference.ReleaseAsset();
            DestroySphere();
            isSphereLoad = false;
        }
    }

    private void OnSphereLoaded(AsyncOperationHandle<GameObject> obj)
    {
        switch(obj.Status)
        {
            case AsyncOperationStatus.Succeeded:
                InstantiateObject(obj.Result);
                break;
            case AsyncOperationStatus.Failed:
                Debug.LogError("OnShereLoaded Failed");
                break;
            default:
                break;
        }
    }

    void InstantiateObject(GameObject obj)
    {
        for(int i = 0; i < 5; i++)
        {
            Vector3 rndVector = new Vector3(UnityEngine.Random.Range(-3, 3), UnityEngine.Random.Range(-3, 3), 0);
            sphereGameObjects.Add(Instantiate(obj, rndVector, Quaternion.identity));
        }
    }

    void DestroySphere()
    {
        for(int i = sphereGameObjects.Count - 1; i >= 0; i--)
        {
            Destroy(sphereGameObjects[i]);
        }
    }
}
