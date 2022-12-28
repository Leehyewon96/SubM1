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
        print("power의 값이" + value + "만큼 증가했습니다. 총 power의 값 =" + power);

    }

    public void SetDefence(int value)
    {
        defence += value;
        print("defence 값이" + value + "만큼 증가했습니다. 총 defence 값 =" + defence);

    }

    private void Start()
    {
        chain += SetPower;
        chain += SetDefence;

        if (chain != null)
            chain(5);
    }
}