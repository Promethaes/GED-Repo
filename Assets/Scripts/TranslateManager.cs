using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranslateManager : MonoBehaviour
{
    public UnityEngine.UI.InputField moveBy;
    public GameObject selectedGameObject;

    float fMoveBy = 0.0f;

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

    public void pX()
    {
        if (selectedGameObject != null)
            selectedGameObject.transform.position = selectedGameObject.transform.position + new Vector3(fMoveBy, 0.0f, 0.0f) * Time.deltaTime;
    }

    public void nX()
    {
        if (selectedGameObject != null)
            selectedGameObject.transform.position = selectedGameObject.transform.position - new Vector3(fMoveBy, 0.0f, 0.0f) * Time.deltaTime;
    }

    public void pY()
    {
        if (selectedGameObject != null)
            selectedGameObject.transform.position = selectedGameObject.transform.position + new Vector3(0.0f, fMoveBy, 0.0f) * Time.deltaTime;
    }

    public void nY()
    {
        if (selectedGameObject != null)
            selectedGameObject.transform.position = selectedGameObject.transform.position - new Vector3(0.0f, fMoveBy, 0.0f) * Time.deltaTime;
    }

    public void pZ()
    {
        if (selectedGameObject != null)
            selectedGameObject.transform.position = selectedGameObject.transform.position + new Vector3(0.0f, 0.0f, fMoveBy) * Time.deltaTime;
    }

    public void nZ()
    {
        if (selectedGameObject != null)
            selectedGameObject.transform.position = selectedGameObject.transform.position - new Vector3(0.0f, 0.0f, fMoveBy) * Time.deltaTime;
    }


    // Update is called once per frame
    void Update()
    {
        float.TryParse(moveBy.text,out fMoveBy);
    }
}
