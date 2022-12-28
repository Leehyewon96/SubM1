using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConcreteSubject : MonoBehaviour
{
    List<Observer> observers = new List<Observer>();

    public void AddObserver(Observer observer)
    {
        observers.Add(observer);
    }

    public void RemoveObserver(Observer observer)
    {
        if (observers.IndexOf(observer) > 0) observers.Remove(observer);
    }

    public void Notify()
    {
        foreach(Observer o in observers)
        {
            o.OnNotify();
        }
    }

    private void Start()
    {
        Observer obj1 = new ConcreteObserver();
        Observer obj2 = new ConcreteObserver2();

        AddObserver(obj1);
        AddObserver(obj2);
    }
}
