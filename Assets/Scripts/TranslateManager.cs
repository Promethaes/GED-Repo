using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranslateManager : MonoBehaviour
{
    public UnityEngine.UI.InputField moveBy;
    public GameObject selectedGameObject;

    public float fMoveBy = 0.0f;

    public List<GameObject> buttons;

    // Start is called before the first frame update
    void Start()
    {
        toggleButtonMenu();
    }

    bool toggle = false;
    public void toggleButtonMenu()
    {
        for (int i = 0; i < buttons.Count; i++)
            buttons[i].SetActive(toggle);

        toggle = !toggle;
    }

    // Update is called once per frame
    void Update()
    {
        float.TryParse(moveBy.text,out fMoveBy);
    }
}
