using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEditor;

//https://support.unity3d.com/hc/en-us/articles/115000341143-How-do-I-read-and-write-data-from-a-text-file-
public class FileIO : MonoBehaviour
{
    StreamWriter writer;
    StreamReader reader;
    public UnityEngine.UI.InputField savePath;
    public ObjManager manager;

    // Start is called before the first frame update
    void Start()
    {
        writer = new StreamWriter("Assets/save.txt");
        writer.Close();
        reader = new StreamReader("Assets/save.txt");
        reader.Close();
        // writer.Write("MeMEs");
        // writer.Close();
        //
        // StreamReader reader = new StreamReader("Assets/save.txt");
        // Debug.Log(reader.ReadToEnd());
        // reader.Close();
    


    }

    public void Save()
    {
        writer = new StreamWriter(savePath.text);

        for(int i = 0; i < manager.objects.Count; i++)
            writer.WriteLine(manager.objects[i].ToString());

        writer.Close();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
