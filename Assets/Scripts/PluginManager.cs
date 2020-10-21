using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Runtime.InteropServices;

public class PluginManager : MonoBehaviour
{
    private const string dllName = "FileIOPro";

    public GameObject prefab;
	
    [StructLayout(LayoutKind.Sequential)] public struct TransformData
    {
        public float xpos, ypos, zpos;
        public float xrot, yrot, zrot, wrot;
        public float xscale, yscale, zscale;
    }

	[DllImport(dllName)]
	public static extern void SetTransformDataToList(float xpos, float ypos, float zpos,
		float xrot, float yrot, float zrot, float wrot, float xscale, float yscale, float zscale);
	[DllImport(dllName)]
	public static extern void ClearAllSavedTransformData();
	[DllImport(dllName)]
	public static extern void Save();
    [DllImport(dllName)]
    public static extern void Load();

    [DllImport(dllName)]
    public static extern int GetNumTransforms();
    [DllImport(dllName)]
    public static extern TransformData GetTransformAt(int index);


    public void SaveAllObjectsToFile()
    {
		var objManager = GameObject.Find("ObjectManager").GetComponent<ObjectManager>();

        //RESTART UNITY
		for(int i = 0; i < objManager.objects.Count; i++)
        {
            SetTransformDataToList(
                objManager.objects[i].transform.position.x,
                objManager.objects[i].transform.position.y,
                objManager.objects[i].transform.position.z,

                objManager.objects[i].transform.rotation.x,
                objManager.objects[i].transform.rotation.y,
                objManager.objects[i].transform.rotation.z,
                objManager.objects[i].transform.rotation.w,

                objManager.objects[i].transform.localScale.x,
                objManager.objects[i].transform.localScale.y,
                objManager.objects[i].transform.localScale.z

                );
        }

        Save();

    }

    public void LoadLevelFromFile()
    {
        var objManager = GameObject.Find("ObjectManager").GetComponent<ObjectManager>();

        Load();

        for(int i = 0; i < GetNumTransforms(); i++)
        {
            var temp = GameObject.Instantiate(prefab);
            temp.GetComponent<DisableOnStartup>().disable = false;
            temp.GetComponent<IsObject>().doNotAddToList = false;
            temp.SetActive(true);
            temp.transform.position = new Vector3(GetTransformAt(i).xpos, GetTransformAt(i).ypos, GetTransformAt(i).zpos);
            temp.transform.localScale = new Vector3(GetTransformAt(i).xscale, GetTransformAt(i).yscale, GetTransformAt(i).zscale);
            temp.transform.rotation = new Quaternion(GetTransformAt(i).xrot, GetTransformAt(i).yrot, GetTransformAt(i).zrot, GetTransformAt(i).wrot);

        }

    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
