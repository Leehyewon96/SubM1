using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delegate : MonoBehaviour
{
    public delegate void ChainFunction(int value);
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
        chain += SetPower;
        chain += SetDefence;

        if (chain != null)
            chain(5);
    }
}