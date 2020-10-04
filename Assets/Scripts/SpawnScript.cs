using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{

    public GameObject prefab;


    // Start is called before the first frame update
    void Start()
    {
        Debug.Assert(prefab.GetComponent<IsObject>());
    }

    public void SpawnObject()
    {
        var temp = GameObject.Instantiate(prefab);
        temp.GetComponent<DisableOnStartup>().disable = false;
        temp.GetComponent<IsObject>().doNotAddToList = false;
        temp.SetActive(true);
        temp.transform.position = new Vector3(0.0f, 1.0f, 0.0f);

        if (prefab.GetComponent<IsObject>().name == "Player")
            gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
