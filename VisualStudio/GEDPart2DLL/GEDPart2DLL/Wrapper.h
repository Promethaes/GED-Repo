#pragma once
#include "TransformData.h"



#ifdef __cplusplus

extern "C" {
#endif

	PLUGIN_API void SetTransformDataToList(float xpos, float ypos, float zpos,
		float xrot, float yrot, float zrot, float wrot,float xscale, float yscale, float zscale);
	PLUGIN_API void ClearAllSavedTransformData();
	PLUGIN_API void Save();
	PLUGIN_API void Load();
	PLUGIN_API int GetNumTransforms();
	PLUGIN_API TransformData GetTransformAt(int index);

#ifdef __cplusplus
}
#endif

