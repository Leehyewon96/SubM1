using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityEvent2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        UnityEvent.OnStart += Abc;
    }

    public void Abc(int value)
    {
        print(value + "���� �����߽��ϴ�");
    }

    // Update is called once per frame
    void Update()
    {

    }
}