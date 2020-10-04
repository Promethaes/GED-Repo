using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteSelectedOBJ : MonoBehaviour
{
    public TranslateManager tManager;
    public ObjectManager objectManager;

    public void DeleteSelected()
    {
        if (tManager.selectedGameObject != null)
            for (int i = 0; i < objectManager.objects.Count; i++)
                if (objectManager.objects[i].gameObject == tManager.selectedGameObject && objectManager.objects[i].name != "Player")
                {
                    objectManager.objects.RemoveAt(i);
                    Destroy(tManager.selectedGameObject);
                    tManager.selectedGameObject = null;
                    return;
                }

    }

}
