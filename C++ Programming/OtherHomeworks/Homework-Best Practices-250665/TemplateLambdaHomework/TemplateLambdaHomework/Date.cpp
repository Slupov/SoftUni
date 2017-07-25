#include <iostream>
#include <string>
#include "Date.hpp"

/// Return string value of date object
std::string Date::getDateToString()
{
	return std::to_string(this->_day) + "." + std::to_string(this->_month) + "." + std::to_string(this->_year);
}