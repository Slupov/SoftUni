#include <iostream>
#include "Vehicle.h"

Vehicle::Vehicle()
{
	registrationNumber = "N/A";
	chassisNumber = "N/A";
	engineNumber = "N/A";
	owner = "N/A";
	weight = 0;
	seatsCount = 0;
}

///////////////////////////////////
void Vehicle::setRegistrationNumber(std::string registNumber)
{
	registrationNumber = registNumber;
}

///////////////////////////////////
void Vehicle::setChassisNumber(std::string _chassisNumber)
{
	chassisNumber = _chassisNumber;
}

///////////////////////////////////
void Vehicle::setEngineNumber(std::string _engineNumber)
{
	engineNumber = _engineNumber;
}

///////////////////////////////////
void Vehicle::setOwner(std::string ownerName)
{
	owner = ownerName;
}

///////////////////////////////////
void Vehicle::setWeight(float _weight)
{
	weight = _weight;
}

///////////////////////////////////
void Vehicle::setSeatsCount(unsigned short int _seatsCount)
{
	seatsCount = _seatsCount;
}

///////////////////////////////////
void Vehicle::setFirstRegistDate(short int _day, short int _month, short int _year)
{
	firstRegistDate.setYear(_year);
	firstRegistDate.setMonth(_month);
	firstRegistDate.setDay(_day);

}

///////////////////////////////////
void Vehicle::setCountryRegistDate(short int _day, short int _month, short int _year)
{
	countryRegistDate.setYear(_year);
	countryRegistDate.setMonth(_month);
	countryRegistDate.setDay(_day);

}

//////////////////////////////////
std::string Vehicle::getRegistrationNumber()
{
	return registrationNumber;
}

///////////////////////////////////
std::string Vehicle::getChassisNumber()
{
	return chassisNumber;
}

///////////////////////////////////
std::string Vehicle::getEngineNumber()
{
	return engineNumber;
}

///////////////////////////////////
std::string Vehicle::getOwner()
{
	return owner;
}

///////////////////////////////////
float Vehicle::getWeight()
{
	return weight;
}

///////////////////////////////////
unsigned short int Vehicle::getSeatsCount()
{
	return seatsCount;
}

///////////////////////////////////
void Vehicle::getFirstRegistDate()
{
	firstRegistDate.displayDate();
}

///////////////////////////////////
void Vehicle::getCountryRegistDate()
{
	countryRegistDate.displayDate();
}

