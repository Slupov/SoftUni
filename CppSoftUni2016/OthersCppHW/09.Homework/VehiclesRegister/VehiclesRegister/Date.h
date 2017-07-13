#include <iostream>
#include <string>
#include <ctime>

#ifndef __DATE_H_
#define __DATE_H_

class Date
{
private:
	tm _firstRegTime;
	tm _lastRegTime;

public:
	//Constructor
	Date(short int firstRegDay, short int firstRegMonth, short int firstRegYear,
		short int lastRegDay, short int lastRegMonth, short int lastRegYear);

	//Copy constructor
	Date(Date& date);

	//Default constructor
	Date() {};

	//Destructor
	~Date() {};

	//Getters and seters to private members
	tm firstRegTime();
	tm lastregTime();

	//Methods
	std::string Date::firstRegToString();
	std::string Date::lastRegToString();

};

#endif // !__DATE_H_
