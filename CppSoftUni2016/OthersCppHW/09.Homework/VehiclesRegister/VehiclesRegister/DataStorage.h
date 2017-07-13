#include <vector>
#include <string>
#include "Vehicles.h"

#ifndef DATASTORAGE_H
#define	DATASTORAGE_H

class DataStorage
{
private:
	std::vector<Vehicle> regVehicles;
	Vehicle* readData();
public:
	DataStorage();
	~DataStorage() {};

	static bool ready;

	void addVehicle();
	void addVehicle (const Vehicle& newVehicles);
	void removeVehicle (std::string regNumber);
	void searchedNumber(std::string regNumber);
};

#endif // !DATASTORAGE_H

