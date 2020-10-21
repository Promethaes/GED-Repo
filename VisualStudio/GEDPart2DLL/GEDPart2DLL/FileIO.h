#pragma once
#include "PluginSettings.h"
#include "TransformData.h"
#include <fstream>
#include <string>

class PLUGIN_API FileIO {
public:

	//will save all of the saved transform data to the specified file
	void Save();
	void Load();

	std::vector<TransformData> savedData;

private:
	std::string fileName;
};

