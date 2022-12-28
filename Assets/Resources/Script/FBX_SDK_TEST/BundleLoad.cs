using System.Collections;
using System.IO;
//using System.Collections.Generic;
using UnityEngine;

public class BundleLoad : MonoBehaviour
{
    private void Start()
    {
        AssetBundle bundle = AssetBundle.LoadFromFile(Path.Combine(Application.dataPath + "/AssetBundles", "cubebundle"));

        if (bundle == null)
        {
            Debug.Log("Failed to load AssetBundle!");
            return;
        }

        var prefab = bundle.LoadAsset<GameObject>("capsulebundle");
        Instantiate(prefab);

        prefab = bundle.LoadAsset<GameObject>("capsulebundle");
        Instantiate(prefab);
    }


}
