#ifndef Date_hpp
#define Date_hpp

#include <string>

class Date {
protected:
	// Attributes
	unsigned short int _day;
	unsigned short int _month;
	unsigned short int _year;
public:
	// Constructors
	Date() 
	{
		
	}

	Date(unsigned short int day, unsigned short int month, unsigned short int year) 
	{
		setDay(day);
		setMonth(month);
		setYear(year);
	}

	~Date()
	{

	}

	// Getters
	unsigned short int getDay()
	{
		return this->_day;
	}

	unsigned short int getMonth()
	{
		return this->_month;
	}

	unsigned short int getYear()
	{
		return this->_year;
	}

	// Setters
	void setDay(unsigned short int &newDay)
	{
		this->_day = newDay;
	}

	void setMonth(unsigned short int &newMonth)
	{
		this->_month = newMonth;
	}

	void setYear(unsigned short int &newYear)
	{
		this->_year = newYear;
	}

	// Method declaration
	std::string getDateToString();
};

#endif /* Date_hpp */