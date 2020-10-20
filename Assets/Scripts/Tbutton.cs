using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tbutton : Command
{
    //should be normalized
    public Vector3 direction;
    TranslateManager tManager;
    List<Vector3> pastPositions = new List<Vector3>();

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
        direction = direction.normalized;
        direction *= tManager.fMoveBy;

        pastPositions.Add(tManager.selectedGameObject.transform.position);

        if (tManager.selectedGameObject != null)
            tManager.selectedGameObject.transform.position = tManager.selectedGameObject.transform.position + direction * Time.deltaTime;
    }

    protected override void undo()
    {
        if (pastPositions.Count == 0)
            return;

        tManager.selectedGameObject.transform.position = pastPositions[pastPositions.Count - 1];
        pastPositions.RemoveAt(pastPositions.Count - 1);

    }

}
