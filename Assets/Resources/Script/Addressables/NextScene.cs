using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class NextScene : MonoBehaviour
{
    public string NextSceneAddress;

    public void OnNextScene()
    {
        Addressables.LoadSceneAsync(NextSceneAddress);
    }
}
