#include "Vehicle.h"
#include <string>

using namespace std;


//getters
string Vehicle::getRegistrationNumber()
{
	return this->registrationNumber;
}
float Vehicle::getWeight()
{
	return this->weight;
}
short Vehicle::getNumberOfSeats()
{
	return this->numberOfSeats;
}
string Vehicle::getChasisNumber()
{
	return this->chasisNumber;
}
string Vehicle::getEngineNumber()
{
	return this->engineNumber;
}
string Vehicle::getOwner()
{
	return this->owner;
}
string Vehicle::getRegistrationDate()
{
	return this->registrationDate.toString();
}
string Vehicle::getType()
{
	return this->type;
}
string Vehicle::getLocalRegistrationDate()
{
	return this->localRegistrationDate.toString();
}


//setters

void Vehicle::setRegistrationNumber(string newValue)
{
	this->registrationNumber = newValue;
}
void Vehicle::setWeight(float newValue)
{
	this->weight = newValue;
}
void Vehicle::setNumberOfSeats(short newValue)
{
	this->numberOfSeats = newValue;
}
void Vehicle::setChasisNumber(string newValue)
{
	this->chasisNumber = newValue;
}
void Vehicle::setEngineNumber(string newValue)
{
	this->engineNumber = newValue;
}
void Vehicle::setOwner(string newValue)
{
	this->owner = newValue;
}
void Vehicle::setRegistrationDate(CalendarDate newValue) // fix this
{
	this->registrationDate = newValue;
}
void Vehicle::setType(string newValue)
{
	this->type = newValue;
}
void Vehicle::setLocalRegistrationDate(CalendarDate newValue)
{
	this->localRegistrationDate = newValue;
}