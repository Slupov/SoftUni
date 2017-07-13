#ifndef VEHICLE_H
#define VEHICLE_H

#include <string>
#include "Date.h"

using namespace std;

class Vehicle
{
	private:
		string registrationNumber;
		string chassisNumber;
		string engineNumber;
		string owner;
		float weight;
		unsigned short int seatsCount;
		Date firstRegistDate;
		Date countryRegistDate;
		
	public:
		Vehicle();
		
		void setRegistrationNumber(string);
		void setChassisNumber(string);
		void setEngineNumber(string);
		void setOwner(string);
		void setWeight(float);
		void setSeatsCount(unsigned short int);
		void setFirstRegistDate(short int, short int, short int);
		void setCountryRegistDate(short int, short int, short int);
		
		string getRegistrationNumber();
		string getChassisNumber();
		string getEngineNumber();
		string getOwner();
		float getWeight();
		unsigned short int getSeatsCount();
		void getFirstRegistDate();
		void getCountryRegistDate();
};

#endif