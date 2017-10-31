#include <iostream>
#include <string>
#include <vector>
#include <ctime>
#include "Flight.h"
#include "Location.h"
#include <set>
#include <memory>
using namespace std;


std::string locationNames[10] = { "Kennedy Space Center", "Of course I still love you", "Where am i", "Is this water", "Strange names",
"Prof. Ghandi", "Baba Yaga", "Studentski", "SoftUni", "Cool name" };

std::string types[4] = { "water", "earth", "moon", "mars"};


void generateLocations(set<shared_ptr<Location>> &locations, unsigned int locationCount)
{
	shared_ptr<Location> currentLocation = make_shared<Location>();
	std::string aString = "";

	srand(time(NULL));
	for (int i = 0; i < locationCount; i++)
	{
		//generate random location name
		int randNum = rand() % 10 + 1;
		currentLocation->set_name(locationNames[randNum]);

		//generate random location type
		randNum = rand() % 4 + 1;
		currentLocation->set_type(types[randNum]);

		//TO DO: implement other attributes like this
		locations.insert(currentLocation);
	}
}