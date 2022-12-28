using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityEvent : MonoBehaviour
{
    public delegate void ChainFunction(int value);
    public static event ChainFunction OnStart;
    ChainFunction chain;

    int power;
    int defence;

    public void SetPower(int value)
    {
        power += value;
        print("power�� ����" + value + "��ŭ �����߽��ϴ�. �� power�� �� =" + power);

    }

    public void SetDefence(int value)
    {
        defence += value;
        print("defence ����" + value + "��ŭ �����߽��ϴ�. �� defence �� =" + defence);

    }

    private void Start()
    {
        OnStart += SetPower;
        OnStart += SetPower;

        if (chain != null)
            chain(5);
    }

    private void OnDisable()
    {
        OnStart(5);
    }
}