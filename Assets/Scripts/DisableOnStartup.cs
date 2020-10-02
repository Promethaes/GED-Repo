using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableOnStartup : MonoBehaviour
{
    public bool disable = false;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(!disable);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
