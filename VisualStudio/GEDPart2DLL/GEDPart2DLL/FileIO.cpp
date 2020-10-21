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

		file << xpos << "\n";
		file << ypos << "\n";
		file << zpos << "\n";

		file << xpos << "\n";
		file << yrot << "\n";
		file << zrot << "\n";
		file << wrot << "\n";

		file << xscale << "\n";
		file << yscale << "\n";
		file << zscale << "\n";


	}

	file.close();
	savedData.clear();
}

void FileIO::Load()
{
	std::ifstream file("./Assets/SAVE.txt");

	savedData.clear();

	while (!file.eof()) {

		std::string xposString = "";
		std::string yposString = "";
		std::string zposString = "";

		std::string xrotString = "";
		std::string yrotString = "";
		std::string zrotString = "";
		std::string wrotString = "";

		std::string xscaleString = "";
		std::string yscaleString = "";
		std::string zscaleString = "";


		file.getline((char*)xposString.c_str(), 256);
		file.getline((char*)yposString.c_str(), 256);
		file.getline((char*)zposString.c_str(), 256);

		file.getline((char*)xrotString.c_str(), 256);
		file.getline((char*)yrotString.c_str(), 256);
		file.getline((char*)zrotString.c_str(), 256);
		file.getline((char*)wrotString.c_str(), 256);

		file.getline((char*)xscaleString.c_str(), 256);
		file.getline((char*)yscaleString.c_str(), 256);
		file.getline((char*)zscaleString.c_str(), 256);


		TransformData temp;

		temp.xpos = std::stof(xposString);
		temp.ypos = std::stof(xposString);
		temp.zpos = std::stof(xposString);

		temp.xrot = std::stof(xrotString);
		temp.yrot = std::stof(yrotString);
		temp.zrot = std::stof(zrotString);
		temp.wrot = std::stof(wrotString);

		temp.xscale = std::stof(xscaleString);
		temp.yscale = std::stof(yscaleString);
		temp.zscale = std::stof(zscaleString);

		savedData.push_back(temp);

	}


}
