using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TManagerSelect : Command
{
    public GameObject selected;
    TranslateManager tManager;
    List<GameObject> prevSelected = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        tManager = GameObject.Find("TranslateManager").GetComponent<TranslateManager>();    
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    protected override void execute()
    {
        tManager.selectedGameObject = selected;
        prevSelected.Add(selected);
    }

    protected override void undo()
    {
        if (prevSelected.Count == 0)
            return;

        selected = prevSelected[prevSelected.Count - 1];
        tManager.selectedGameObject = prevSelected[prevSelected.Count - 1];
        prevSelected.RemoveAt(prevSelected.Count - 1);
    }

}
