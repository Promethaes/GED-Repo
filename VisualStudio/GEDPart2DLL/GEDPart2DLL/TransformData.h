#pragma once
#include "PluginSettings.h"
#include <vector>

struct TransformData
{
	float xpos, ypos, zpos;
	float xrot, yrot, zrot, wrot;
	float xscale, yscale, zscale;

	void ClearData() {
		xpos = 0;
		ypos = 0;
		zpos = 0;
	
		xrot = 0;
		yrot = 0;
		zrot = 0;
		wrot = 0;

		xscale = 0;
		yscale = 0;
		zscale = 0;
	}
};

