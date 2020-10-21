#include "FileIO.h"
void FileIO::Save()
{
	std::ofstream file("./Assets/SAVE.txt");

	for (int i = 0; i < savedData.size(); i++) {
		
		std::string xpos = std::to_string(savedData[i].xpos);
		std::string ypos = std::to_string(savedData[i].ypos);
		std::string zpos = std::to_string(savedData[i].zpos);

		std::string xrot = std::to_string(savedData[i].xrot);
		std::string yrot = std::to_string(savedData[i].yrot);
		std::string zrot = std::to_string(savedData[i].zrot);
		std::string wrot = std::to_string(savedData[i].wrot);

		std::string xscale = std::to_string(savedData[i].xscale);
		std::string yscale = std::to_string(savedData[i].yscale);
		std::string zscale = std::to_string(savedData[i].zscale);

		file.write(xpos.c_str(), xpos.length());
		file.write(ypos.c_str(), ypos.length());
		file.write(zpos.c_str(), zpos.length());

		file.write(xrot.c_str(), xrot.length());
		file.write(yrot.c_str(), yrot.length());
		file.write(zrot.c_str(), zrot.length());
		file.write(wrot.c_str(), wrot.length());

		file.write(xscale.c_str(), xscale.length());
		file.write(yscale.c_str(), yscale.length());
		file.write(zscale.c_str(), zscale.length());



	}

	file.close();
}

void FileIO::Load()
{
	std::ifstream file("./Assets/SAVE.txt");

	while (!file.eof()) {

		std::string xposString = "";



	}
}
