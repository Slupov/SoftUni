#ifndef Vehicle_hpp
#define Vehicle_hpp

#include <string>
#include "Date.hpp"

class Vehicle {
protected:
	// Attributes
	std::string _registrationNumber;
	float _weight;
	short int _seatsCount;
	std::string _chassisNumber;
	std::string _engineNumber;
	std::string _owner;
	Date _dateFirstRegistration;
	Date _dateCurrentRegistration;
public:
	// Constructors
	Vehicle();

	Vehicle(
		std::string registrationNumber,
		float weight,
		short int seatsCount,
		std::string chassisNumber,
		std::string engineNumber,
		std::string owner,
		Date dateFirstRegistration,
		Date dateCurrentRegistration)
	{
		setRegistrationNumber(registrationNumber);
		setWeight(weight);
		setSeatsCount(seatsCount);
		setChassisNumber(chassisNumber);
		setEngineNumber(engineNumber);
		setOwner(owner);
		setDateFirstRegistration(dateFirstRegistration);
		setDateCurrentRegistration(dateCurrentRegistration);
	}

	~Vehicle()
	{

	}

	// Getters
	std::string getRegistrationNumber()
	{
		return this->_registrationNumber;
	}

	float getWeight()
	{
		return this->_weight;
	}

	short int getSeatsCount()
	{
		return this->_seatsCount;
	}

	std::string getChassisNumber()
	{
		return this->_chassisNumber;
	}

	std::string getEngineNumber()
	{
		return this->_engineNumber;
	}

	std::string getOwner()
	{
		return this->_owner;
	}

	Date getDateFirstRegistration()
	{
		return this->_dateFirstRegistration;
	}
	
	Date getDateCurrentRegistration()
	{
		return this->_dateCurrentRegistration;
	}

	// Setters
	void setRegistrationNumber(std::string &newRegistrationNumber)
	{
		this->_registrationNumber = newRegistrationNumber;
	}

	void setWeight(float &newWeight)
	{
		this->_weight = newWeight;
	}

	void setSeatsCount(short int &newSeatsCount)
	{
		this->_seatsCount = newSeatsCount;
	}

	void setChassisNumber(std::string &newChassisNumber)
	{
		this->_chassisNumber = newChassisNumber;
	}

	void setEngineNumber(std::string &newEngineNumber)
	{
		this->_engineNumber = newEngineNumber;
	}

	void setOwner(std::string &newOwner)
	{
		this->_owner = newOwner;
	}

	void setDateFirstRegistration(Date &newDateFirstRegistration)
	{
		this->_dateFirstRegistration = newDateFirstRegistration;
	}
	
	void setDateCurrentRegistration(Date &newDateCurrentRegistration)
	{
		this->_dateCurrentRegistration = newDateCurrentRegistration;
	}

	// Methods declaration
	void printVehicleInformation();
};

#endif /* Vehicle_hpp */