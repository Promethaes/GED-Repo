using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : Command
{

    public GameObject prefab;
    public List<GameObject> spawnedObjects = new List<GameObject>();
    public List<GameObject> despawnedObjects = new List<GameObject>();
    public int maxNumInactives = 3;//max number of inactive despawned objects before they start becoming deleted

    // Start is called before the first frame update
    void Start()
    {
    }


    protected override void execute()
    {
        SpawnObject();
    }
    protected override void undo()
    {
        spawnedObjects[spawnedObjects.Count - 1].SetActive(false);
        despawnedObjects.Add(spawnedObjects[spawnedObjects.Count - 1]);
        spawnedObjects.RemoveAt(spawnedObjects.Count - 1);
    }

    public void SpawnObject()
    {
        var temp = GameObject.Instantiate(prefab);
        temp.GetComponent<DisableOnStartup>().disable = false;
        temp.GetComponent<IsObject>().doNotAddToList = false;
        temp.SetActive(true);
        temp.transform.position = new Vector3(0.0f, 1.0f, 0.0f);
        spawnedObjects.Add(temp);

        if (prefab.GetComponent<IsObject>().name == "Player")
            gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
