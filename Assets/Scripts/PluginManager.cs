using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Runtime.InteropServices;

public class PluginManager : MonoBehaviour
{
    private const string dllName = "FileIOPro";

	
    [StructLayout(LayoutKind.Sequential)] public struct TransformData
    {
        float xpos, ypos, zpos;
        float xrot, yrot, zrot, wrot;
        float xscale, yscale, zscale;
    }

	[DllImport(dllName)]
	public static extern void SetTransformDataToList(float xpos, float ypos, float zpos,
		float xrot, float yrot, float zrot, float wrot, float xscale, float yscale, float zscale);
	[DllImport(dllName)]
	public static extern void ClearAllSavedTransformData();
	[DllImport(dllName)]
	public static extern void Save();


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
