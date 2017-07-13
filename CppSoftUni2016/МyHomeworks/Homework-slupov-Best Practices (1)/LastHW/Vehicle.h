#include <iostream>
#include <string>
#include "CalendarDate.h"

using namespace std;

class Vehicle
{
public:
	string registrationNumber;
	float weight; // in tones
	short numberOfSeats;
	string chasisNumber;
	string engineNumber;
	string owner;
	CalendarDate registrationDate;
	CalendarDate localRegistrationDate;
	string type;

	//getters
	string getRegistrationNumber();
	float getWeight();
	short getNumberOfSeats();
	string getChasisNumber();
	string getEngineNumber();
	string getOwner();
	string getRegistrationDate();
	string getType();
	string getLocalRegistrationDate();
	
	//setters

	void setRegistrationNumber(string newValue);
	void setWeight(float newValue);
	void setNumberOfSeats(short newValue);
	void setChasisNumber(string newValue);
	void setEngineNumber(string newValue);
	void setOwner(string newValue);
	void setRegistrationDate(CalendarDate newValue);
	void setType(string newValue);
	void setLocalRegistrationDate(CalendarDate newValue);
};