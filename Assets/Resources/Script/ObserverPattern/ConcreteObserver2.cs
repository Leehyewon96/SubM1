using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConcreteObserver2 : Observer
{
    public override void OnNotify()
    {
        Debug.Log("옵저버 클래스의 메서드 실행 #2");
    }
}
