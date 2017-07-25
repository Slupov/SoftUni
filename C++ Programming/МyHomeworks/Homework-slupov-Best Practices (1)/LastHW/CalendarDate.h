#include <iostream>
#include <sstream>
using namespace std;

class CalendarDate
{
public:
	int day;
	int month;
	int year;

	CalendarDate(){};

	CalendarDate(int day, int month, int year): day(day),
	month(month),year(year){};

	int getDay()
	{
		return this->day;
	}
	int getMonth()
	{
		return this->month;
	}
	int getYear()
	{
		return this->year;
	}
	void setDay(int newValue)
	{
		this->day = newValue;
	}
	void setMonth(int newValue)
	{
		this->month = newValue;
	}
	void setYear(int newValue)
	{
		this->year = newValue;
	}

	string toString()
	{
		//Implement
		string dayStr = static_cast<ostringstream*>(&(ostringstream() << this->day))->str();
		string monthStr = static_cast<ostringstream*>(&(ostringstream() << this->month))->str();
		string yearStr = static_cast<ostringstream*>(&(ostringstream() << this->year))->str();

		return dayStr + "." + monthStr + "." + yearStr;
	}

};