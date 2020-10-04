using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveatePlayMode : MonoBehaviour
{
    public ObjectManager objectManager;

    public void TogglePlayMode()
    {
        if (objectManager.playerObject != null)
            objectManager.playerObject.GetComponent<PlayerMove>().ourPlayMode = !objectManager.playerObject.GetComponent<PlayerMove>().ourPlayMode;
    }


    // Update is called once per frame
    void Update()
    {

    }
}
