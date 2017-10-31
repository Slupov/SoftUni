#include <iostream>
#include <string>
#include <vector>
#include <ctime>
#include "Flight.h"
#include "Location.h"
#include <set>
using namespace std;


std::string rocketNames[10] = { "Apolo 1", "Apolo 2", "Apoloncho", "Eva III", "Elizabeth",
"Ivan Stranski", "Yurii", "Paul Pogba", "St.Nakov", "Ubihard" };

std::string missionNames[10] = { "Mission Impossible", "All the way up", "Fiki", "Mama Goshka", "Millionaire",
"Iker", "Sky is the limit", "Blue", "Red", "Yellow" };



void generateFlights(set<shared_ptr<Flight>> &flights, unsigned int flightCount)
{
	shared_ptr<Flight> currentFlight = make_shared<Flight>();
	std::string aString = "";

	srand(time(NULL));
	for (int i = 0; i < flightCount; i++)
	{
		//generate random mission name
		int randNum = rand() % 10 + 1;
		currentFlight->set_mission_name(missionNames[randNum]);

		//generate random rocket name
		randNum = rand() % 10 + 1;
		currentFlight->set_rocket_name(rocketNames[randNum]);

		//generate random weight
		randNum = (double)(rand() % 5000 + 1)/(rand()%2 + 0.3212);
	
		//generate random flight time in seconds
		randNum = (double)(rand() % 10000000 + 1);
		//generate flight success
		randNum = rand()%2;
		if (randNum == 1)
		{
			currentFlight->set_land_success(false);
		}
		else
		{
			currentFlight->set_land_success(true);

		}
		//generate random coordinates
		randNum = rand()%180;
		currentFlight->coordinates[0] = randNum;
		currentFlight->coordinates[1] = randNum; //can add a floating point
		
		flights.insert(currentFlight);
	}
}