#pragma once
#include <iostream>
#include <string>
using namespace std;
class Flight
{
private:
	string missionName;
	string rocketName;
	string launchDate;
	string landingDate;
	double weight; // in kg (double because its of high importance)
	long long flightTime; // in seconds
	bool landSuccess;



public:
	double coordinates[2];

	void toString();

	string mission_name() const
	{
		return missionName;
	}

	void set_mission_name(string mission_name)
	{
		missionName = mission_name;
	}

	string rocket_name() const
	{
		return rocketName;
	}

	void set_rocket_name(string rocket_name)
	{
		rocketName = rocket_name;
	}

	string launch_date() const
	{
		return launchDate;
	}

	void set_launch_date(string launch_date)
	{
		launchDate = launch_date;
	}

	string landing_date() const
	{
		return landingDate;
	}

	void set_landing_date(string landing_date)
	{
		landingDate = landing_date;
	}

	double weight1() const
	{
		return weight;
	}

	void set_weight(double weight)
	{
		this->weight = weight;
	}

	long long flight_time() const
	{
		return flightTime;
	}

	void set_flight_time(long long flight_time)
	{
		flightTime = flight_time;
	}

	bool land_success() const
	{
		return landSuccess;
	}

	void set_land_success(bool land_success)
	{
		landSuccess = land_success;
	}

	Flight();
	~Flight();

};

