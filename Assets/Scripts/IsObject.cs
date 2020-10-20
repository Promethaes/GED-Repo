using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsObject : MonoBehaviour
{
    public ObjectManager manager;
    public string name;
    public TManagerSelect tSelect;
    public bool doNotAddToList = false;

    // Start is called before the first frame update
    void Start()
    {
        if (!doNotAddToList)
            manager.objects.Add(this);
        tSelect = GameObject.Find("TManagerSelect").GetComponent<TManagerSelect>();
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
    }

    private void OnMouseDown()
    {
        tSelect.selected = gameObject;
        tSelect.TrackAndExecute();
    }


}
