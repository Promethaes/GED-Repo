#include "Wrapper.h"
#include "FileIO.h"

FileIO f;


void SetTransformDataToList(float xpos, float ypos, float zpos, float xrot, float yrot, float zrot, float wrot, float xscale, float yscale, float zscale)
{
	TransformData data;
	data.xpos = xpos;
	data.ypos = ypos;
	data.zpos = zpos;

	data.xrot = xrot;
	data.yrot = yrot;
	data.zrot = zrot;
	data.wrot = wrot;

	data.xscale = xscale;
	data.yscale = yscale;
	data.zscale = zscale;


	f.savedData.push_back(data);
}

void ClearAllSavedTransformData()
{
	f.savedData.clear();
}

void Save()
{
	f.Save();
}

void Load()
{
	f.Load();
}

int GetNumTransforms()
{
	return f.savedData.size();
}

TransformData GetTransformAt(int index)
{
	return f.savedData[index];
}
