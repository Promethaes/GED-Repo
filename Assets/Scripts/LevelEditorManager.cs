using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEditorManager : MonoBehaviour
{

    public List<GameObject> SpawnButtons;



    // Start is called before the first frame update
    void Start()
    {
        toggleButtonMenu();
    }


    bool toggle = false;
    public void toggleButtonMenu()
    {
        for(int i = 0; i < SpawnButtons.Count; i++)
            SpawnButtons[i].SetActive(toggle);

        toggle = !toggle;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
