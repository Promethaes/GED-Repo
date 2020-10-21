using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Observer : MonoBehaviour
{

    GameObject subject;

    public abstract void ObserverUpdate();

}
