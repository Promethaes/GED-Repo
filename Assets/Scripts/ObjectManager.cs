using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    public List<IsObject> objects = new List<IsObject>();

    public GameObject playerObject;

    public GameObject playerSpawnButton;

    public List<GameObject> prefabs;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int counter = 0;
        int index = 0;
        for (int i = 0; i < objects.Count; i++)
        {
            if (objects[i].GetComponent<IsObject>().name == "Player")
            {
                counter++;
                playerObject = objects[i].gameObject;
            }

            if (counter == 2)
                index = i;
        }

        if(counter == 2)
        {
            Destroy(objects[index] != null ? objects[index] : null);
            objects.RemoveAt(index);
        }

    }
}
