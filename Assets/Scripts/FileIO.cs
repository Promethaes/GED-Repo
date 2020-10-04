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
    public UnityEngine.UI.InputField loadPath;
    public ObjectManager manager;

    // Start is called before the first frame update
    void Start()
    {
        writer = new StreamWriter("Assets/save.txt");
        writer.Close();
        reader = new StreamReader("Assets/save.txt");
        reader.Close();
    }

    public void Save()
    {

        if (!savePath.text.Contains(".txt"))
            return;

        writer = new StreamWriter(savePath.text);

        for (int i = 0; i < manager.objects.Count; i++)
        {
            if (manager.objects[i].name == "Player")
                continue;

            writer.WriteLine("!object: " + manager.objects[i].name);
            writer.WriteLine(manager.objects[i].transform.position.x);
            writer.WriteLine(manager.objects[i].transform.position.y);
            writer.WriteLine(manager.objects[i].transform.position.z);

            writer.WriteLine(manager.objects[i].transform.rotation.x);
            writer.WriteLine(manager.objects[i].transform.rotation.y);
            writer.WriteLine(manager.objects[i].transform.rotation.z);
            writer.WriteLine(manager.objects[i].transform.rotation.w);

            writer.WriteLine(manager.objects[i].transform.localScale.x);
            writer.WriteLine(manager.objects[i].transform.localScale.y);
            writer.WriteLine(manager.objects[i].transform.localScale.z);
        }

        writer.Close();
    }

    public void Load()
    {

        for (int i = 0; i < manager.objects.Count; i++)
        {
            if (manager.objects[i].gameObject.activeSelf)
            {
                manager.objects[i].DeleteSelf();
                manager.objects.RemoveAt(i);
                i--;
            }
        }

        if (!loadPath.text.Contains(".txt"))
            return;

        reader = new StreamReader(loadPath.text);

        int numObjects = 0;

        string fileAsString = reader.ReadToEnd();

        for (int i = 0; i < fileAsString.Length; i++)
            if (fileAsString[i] == '!')
                numObjects++;


        reader.Close();

        var currentLine = "";
        reader = new StreamReader(loadPath.text);
        for (int j = 0; j < numObjects; j++)
        {
            currentLine = reader.ReadLine();

            for (int i = 0; i < manager.prefabs.Count; i++)
            {

                if (currentLine.Contains(manager.prefabs[i].GetComponent<IsObject>().name))
                {
                    var temp = GameObject.Instantiate(manager.prefabs[i]);
                    temp.GetComponent<DisableOnStartup>().disable = false;

                    var x = reader.ReadLine();
                    var y = reader.ReadLine();
                    var z = reader.ReadLine();

                    temp.gameObject.transform.position = new Vector3(float.Parse(x), float.Parse(y), float.Parse(z));

                    x = reader.ReadLine();
                    y = reader.ReadLine();
                    z = reader.ReadLine();
                    var w = reader.ReadLine();
                    temp.gameObject.transform.rotation = new Quaternion(float.Parse(x), float.Parse(y), float.Parse(z), float.Parse(w));


                    x = reader.ReadLine();
                    y = reader.ReadLine();
                    z = reader.ReadLine();
                    temp.gameObject.transform.localScale = new Vector3(float.Parse(x), float.Parse(y), float.Parse(z));


                    temp.gameObject.GetComponent<IsObject>().doNotAddToList = false;
                    temp.gameObject.SetActive(true);
                    break;
                }

            }

        }
        reader.Close();


    }

    // Update is called once per frame
    void Update()
    {

    }
}
