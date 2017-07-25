#include <iostream>
#include <string>
#include <vector>
#include <ctime>
#include "Vehicle.h"

std::string firstNames[10] = { "Gosho", "Pesho", "Tosho", "Marto", "Hristo",
								"Misho", "Mitko", "Tisho", "Ivo", "Genadi" };

std::string lastNames[10] = { "Georgiev", "Petrov", "Todorov", "Gerganov", "Hristov",
								"Vyrbev", "Evstatiev", "Mihalev", "Kostov", "Madzunkov"};


void generateVehicles(std::vector<Vehicle> &vehicles, unsigned int vehicleNumber)
{
	Vehicle vehicle;
	char letter, randChar;
	unsigned short int randNum, day, month, year, firstYear;
	float weight;
	std::string aString = "";

	srand(time(NULL));
	for (int i = 0; i < vehicleNumber; i++)
	{
		randChar = rand() % 26 + 65;				//generate registration
		aString += randChar;
		randChar = rand() % 10 + 48;
		aString += randChar;
		randChar = rand() % 10 + 48;
		aString += randChar;
		randChar = rand() % 10 + 48;
		aString += randChar;
		randChar = rand() % 10 + 48;
		aString += randChar;
		randChar = rand() % 26 + 65;
		aString += randChar;
		randChar = rand() % 26 + 65;
		aString += randChar;
		vehicle.setRegistrationNumber(aString);

		aString = "";								//generate chassis number
		for (int j = 0; j < 15; j++)
		{
			randChar = rand() % 10 + 48;
			aString += randChar;
		}
		vehicle.setChassisNumber(aString);

		aString = "";								//generate engine number
		for (int j = 0; j < 9; j++)
		{
			randChar = rand() % 10 + 48;
			aString += randChar;
		}
		vehicle.setEngineNumber(aString);

		aString = "";								//generate owner name
		randNum = rand() % 10;
		aString += firstNames[randNum] + " ";
		randNum = rand() % 10;
		aString += lastNames[randNum];
		vehicle.setOwner(aString); 

		weight = ((double) rand()) / RAND_MAX * 40 ;	//generate weight
		vehicle.setWeight(weight);

		randNum = rand() % 5 + 1;				 //generate number of seats
		vehicle.setSeatsCount(randNum);

		day = rand() % 30 + 1;					//generate first registration date
		month = rand() % 12 + 1;
		year = rand() % 45 + 1971;
		vehicle.setFirstRegistDate(day, month, year);

		day = rand() % 30 + 1;					//generate country registration date
		month = rand() % 12 + 1;
		firstYear = year;
		do
		{
			year = rand() % 45 + 1971;
		} while (year < firstYear);
		vehicle.setCountryRegistDate(day, month, year);

		vehicles.push_back(vehicle);
	}
}