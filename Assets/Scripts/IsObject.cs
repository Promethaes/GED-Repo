﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsObject : MonoBehaviour
{
    public ObjectManager manager;
    public string name;

    // Start is called before the first frame update
    void Start()
    {
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
}