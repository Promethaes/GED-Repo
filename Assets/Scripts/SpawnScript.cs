using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{

    public GameObject prefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SpawnObject()
    {
        var temp = GameObject.Instantiate(prefab);
        temp.transform.position = new Vector3(0.0f, 10.0f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
