#include <ctime>
#include <string>
#include "Date.h"

Date::Date(short int firstRegDay, short int firstRegMonth, short int firstRegYear,
	short int lastRegDay, short int lastRegMonth, short int lastRegYear)
{
	this->_firstRegTime.tm_mday = firstRegDay;
	this->_firstRegTime.tm_mon = firstRegMonth;
	this->_firstRegTime.tm_year = firstRegYear;
	this->_lastRegTime.tm_mday = lastRegDay;
	this->_lastRegTime.tm_mon = lastRegMonth;
	this->_lastRegTime.tm_year = lastRegYear;
};

Date::Date(Date& date)
{
	this->_firstRegTime = date.firstRegTime();
	this->_lastRegTime = date.lastregTime();
}

tm Date::firstRegTime() { return _firstRegTime; }
tm Date::lastregTime() { return _lastRegTime; }
std::string Date::firstRegToString()
{
	return std::to_string(this->_firstRegTime.tm_mday) + "." + std::to_string(this->_firstRegTime.tm_mon) + "." + std::to_string(this->_firstRegTime.tm_year);
}

std::string Date::lastRegToString()
{
	return std::to_string(this->_lastRegTime.tm_mday) + "." + std::to_string(this->_lastRegTime.tm_mon) + "." + std::to_string(this->_lastRegTime.tm_year);
}

////get the starting value of clock
//clock_t start = clock();
//tm* my_time;
//
//
////get current time in format of time_t
//time_t t = time(NULL);
//
//
////show the value stored in t
//cout << "Value of t " << t << endl;
//
////convert time_t to char*
//char* charTime = ctime(&t);
//
////display current time
//cout << "Now is " << charTime << endl;
//
////convert time_t to tm
//my_time = localtime(&t);
//
////get only hours and minutes
//char* hhMM = new char[6];
//strftime(hhMM, 6, "HH:MM", my_time);