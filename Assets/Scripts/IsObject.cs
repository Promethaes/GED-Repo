using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsObject : MonoBehaviour
{
    public ObjectManager manager;
    public string name;
    public TranslateManager tManager;
    public bool doNotAddToList = false;

    // Start is called before the first frame update
    void Start()
    {
        if (!doNotAddToList)
            manager.objects.Add(this);
    }

    public void DeleteSelf()
    {
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseOver()
    {
        Debug.Log("Works");
    }

    private void OnMouseDown()
    {
        tManager.selectedGameObject = gameObject;
    }


}
