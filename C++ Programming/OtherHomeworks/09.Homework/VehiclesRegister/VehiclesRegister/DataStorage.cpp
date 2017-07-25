#include <string>
#include <iostream>
#include <algorithm>
#include "DataStorage.h"
#include "Vehicles.h"

bool DataStorage::ready;

DataStorage::DataStorage() { ready = false; }

void DataStorage::addVehicle(const Vehicle& newVehicle)
{
	regVehicles.push_back(newVehicle);
};

void DataStorage::addVehicle()
{
	regVehicles.push_back(*readData());
}

void DataStorage::removeVehicle(std::string regNumber)
{
	auto res = for_each(this->regVehicles.begin(), this->regVehicles.end(), 
		[regNumber](Vehicle& vehicle) {return regNumber == vehicle.getRegNumber(); });
};

void DataStorage::searchedNumber(std::string regNumber)
{
	if (this->regVehicles.end() != this->regVehicles.begin())
	{
		for_each(this->regVehicles.begin(), this->regVehicles.end(),
			[regNumber](Vehicle& vehicle) {
			if (regNumber == vehicle.getRegNumber())
			{
			vehicle.printVehicle();
			ready = true;
			};
		});
	}
}

Vehicle* DataStorage::readData()
{
	std::string regNumber;
	float weightTone;
	short int numOfSeats;
	std::string chasisNumber;
	std::string engineNumber;
	std::string owner;
	int dayFirst;
	int monthFirst;
	int yearFirst;
	int dayLast;
	int monthLast;
	int yearLast;

	std::cout << "Enter registration number: ";
	std::cin >> regNumber;
	std::cin.ignore();
	std::cout << "Enter weight in tones: ";
	std::cin >> weightTone;
	std::cin.ignore();
	std::cout << "Enter number of seats: ";
	std::cin >> numOfSeats;
	std::cout << "Enter the chasis number: " ;
	std::cin >> chasisNumber;
	std::cin.ignore();
	std::cout << "Enter the engine number: " ;
	std::cin >> engineNumber;
	std::cin.ignore();
	std::cout << "Enter the car's owner: " ;
	std::cin >> owner;
	std::cin.ignore();
	std::cout << "Enter the first registration date" << std::endl;
	std::cout << "Day: ";
	std::cin >> dayFirst;
	std::cin.ignore();
	std::cout << "Month: ";
	std::cin >> monthFirst;
	std::cin.ignore();
	std::cout << "Year: ";
	std::cin >> yearFirst;
	std::cin.ignore();
	std::cout << "Enter the last registration date: "<< std::endl;
	std::cout << "Day: ";
	std::cin >> dayLast;
	std::cin.ignore();
	std::cout << "Month: ";
	std::cin >> monthLast;
	std::cin.ignore();
	std::cout << "Year: ";
	std::cin >> yearLast;
	std::cin.ignore();
	Date regDate = Date(dayFirst, monthFirst, yearFirst, dayLast, monthLast, yearLast);

	Vehicle newVehicle = Vehicle(regNumber, weightTone, numOfSeats, chasisNumber, engineNumber, owner, regDate);

	return &newVehicle;
}	
	