using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteSelectedOBJ : Command
{
    public TranslateManager tManager;
    public ObjectManager objectManager;

    List<GameObject> deletedGameObjects = new List<GameObject>();

    public void DeleteSelected()
    {
        if (tManager.selectedGameObject != null)
            for (int i = 0; i < objectManager.objects.Count; i++)
                if (objectManager.objects[i].gameObject == tManager.selectedGameObject && objectManager.objects[i].name != "Player")
                {
                    objectManager.objects.RemoveAt(i);
                    tManager.selectedGameObject.SetActive(false);
                    deletedGameObjects.Add(tManager.selectedGameObject);
                    tManager.selectedGameObject = null;
                    return;
                }

    }

    protected override void execute()
    {
        DeleteSelected();
    }

    protected override void undo()
    {
        deletedGameObjects[deletedGameObjects.Count - 1].SetActive(true);
        tManager.selectedGameObject = deletedGameObjects[deletedGameObjects.Count - 1];
        objectManager.objects.Add(tManager.selectedGameObject.GetComponent<IsObject>());
        deletedGameObjects.RemoveAt(deletedGameObjects.Count - 1);
    }



}
