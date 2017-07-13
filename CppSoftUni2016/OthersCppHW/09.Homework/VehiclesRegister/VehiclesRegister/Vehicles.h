#include <iostream>
#include <string>
#include "Date.h"

#ifndef VEHICLES_H
#define VEHICLES_H

class Vehicle
{
private:
	std::string regNumber;
	float weightTone;
	short int numOfSeats;
	std::string chasisNumber;
	std::string engineNumber;
	std::string owner;
	Date regDate;

public:
	inline Vehicle(std::string regNum, float weight, short int numOfSeats,
		std::string chasisNumber, std::string engineNumber,
		std::string owner, Date dates)
	{
		this->regNumber = regNum;
		this->weightTone = weight;
		this->numOfSeats = numOfSeats;
		this->chasisNumber = chasisNumber;
		this->engineNumber = engineNumber;
		this->owner = owner;
		this->regDate = dates;
	}

	inline Vehicle(const Vehicle & newVehicles)
	{
		this->regNumber = newVehicles.regNumber;
		this->weightTone = newVehicles.weightTone;
		this->numOfSeats = newVehicles.numOfSeats;
		this->chasisNumber = newVehicles.chasisNumber;
		this->engineNumber = newVehicles.engineNumber;
		this->owner = newVehicles.owner;
		this->regDate = newVehicles.regDate;
	}

	~Vehicle() {};

	//Getters and setters for private variables
	std::string getRegNumber() const { return regNumber; }
	float getWeightTone() const { return weightTone; }
	short int getNumOfSeats() const { return numOfSeats; }
	std::string getChasisNumber() const { return chasisNumber; }
	std::string getEngineNumber() const { return engineNumber; }
	std::string getOwner() const { return owner; }
	Date getFirstRegDaTe() { return regDate; }

	//Public functions
	void printVehicle()
	{
		std::cout << this->regNumber << std::endl;
		std::cout << "Weight: " << this->weightTone << " t" << std::endl;
		std::cout << "Number of seats : " << this->numOfSeats << std::endl;
		std::cout << "Chassis number : " << this->chasisNumber << std::endl;
		std::cout << "Engine number : " << this->engineNumber << std::endl;
		std::cout << "Owner : " << this->owner << std::endl;
		std::cout << "Date of first registration : " << this->regDate.firstRegToString() << std::endl;
		std::cout << "Date of registration in country : " << this->regDate.lastRegToString() << std::endl;
		std::cout << std::endl;
	}
};

#endif // !VEHICLES_H
