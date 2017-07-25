#include <iostream>
#include <iomanip>

#include "Date.h"

Date::Date()
{
	day = 1;
	month = 1;
	year = 1970;
}

///////////////////////////////////
Date::Date(unsigned short int _day, unsigned short int _month, unsigned short int _year)
{
	setYear(_year);
	setMonth(_month);
	setDay(_day);
}

///////////////////////////////////
void Date::setDay(unsigned short int _day)
{
	/*if(month == -1)
		std::cout << "Error: Month is -1, setting day to -1\n" << std::endl;
	
	if(month == 2 && (year % 4 == 0 && (year % 100 != 0 && year % 400 == 0)))
	{
		if(_day > 29 || _day == 0)
		{
			std::cout << "Error: The day cannot be 0 or more than 29, " 
			"setting to -1\n" << std::endl;
			day = -1;
			return;
		}
	}
	else if(month == 2)
	{
		if(_day > 28 || _day == 0)
		{
			std::cout << "Error: The day cannot be 0 or more than 28, " 
			"setting to -1\n" << std::endl;
			day = -1;
			return;
		}
	}
	else if((month < 8 && month % 2 != 0) || (month >= 8 && month % 2 == 0))
	{
		if(_day > 31 || _day == 0)
		{
			std::cout << "Error: The day cannot be 0 or more than 31, " 
			"setting to -1\n" << std::endl;
			day = -1;
			return;
		}
	}
	else if((month > 8 && month % 2 != 0) || (month < 7 && month % 2 == 0))
	{
		if(_day > 30 || _day == 0)
		{
			std::cout << "Error: The day cannot be 0 or more than 30, " 
			"setting to -1\n" << std::endl;
			day = -1;
			return;
		}
	}*/
	
	day = _day;
}

///////////////////////////////////
void Date::setMonth(unsigned short int _month)
{
	/*if (_month == 0 || _month > 12)
	{
		std::cout << "Error: The month cannot be 0 or more than 12, "
			"setting to -1\n" << std::endl;
		month = -1;
		return;
	}*/

	month = _month;
}

///////////////////////////////////
void Date::setYear(unsigned short int _year)
{
	year = _year;
}

//////////////////////////////////
unsigned short int Date::getDay()
{
	return day;
}

///////////////////////////////////
unsigned short int Date::getMonth()
{
	return month;
}

///////////////////////////////////
unsigned short int Date::getYear()
{
	return year;
}

///////////////////////////////////
void Date::displayDate()
{
	std::cout << std::setfill('0') << std::setw(2) << getDay()
		<< "." << getMonth() << "." << std::setw(4) << getYear();
}



