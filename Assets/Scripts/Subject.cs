using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Subject : MonoBehaviour
{

    private List<Observer> m_observers = new List<Observer>();

    private string m_state;

    public string getState()
    {
        return m_state;
    }

    public void setState(string state)
    {
        m_state = state;
        notifyObservers();
    }

    public void attach(Observer observer)
    {
        m_observers.Add(observer);
    }

    public void notifyObservers()
    {
        //Cycles through and updates all observers
        for (int i = 0; i < m_observers.Count; i++)
        {
            m_observers[i].ObserverUpdate();
        }
    }

}
