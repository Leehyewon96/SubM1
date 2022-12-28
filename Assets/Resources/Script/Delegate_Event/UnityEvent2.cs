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
        print(value + "값이 증가했습니다");
    }

    // Update is called once per frame
    void Update()
    {

    }
}