using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConcreteObserver2 : Observer
{
    public override void OnNotify()
    {
        Debug.Log("������ Ŭ������ �޼��� ���� #2");
    }
}
