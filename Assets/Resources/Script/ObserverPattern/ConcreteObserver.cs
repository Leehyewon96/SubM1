using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConcreteObserver : Observer
{
    public override void OnNotify()
    {
        Debug.Log("������ Ŭ������ �޼��� ���� #1");
    }
}
