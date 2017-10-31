#pragma once
#include<iostream>
#include <string>
#include "Flight.h"
#include <set>
using namespace std;
class Location
{
private:
	string name;
	string type;
	int landingTries;
	set<Flight> successfulLandings;
	int successfulLandingsCount;
public:
	Location();
	~Location();

	//getters and setters
	string name1() const
	{
		return name;
	}

	void set_name(string name)
	{
		this->name = name;
	}

	string type1() const
	{
		return type;
	}

	void set_type(string type)
	{
		this->type = type;
	}

	int landing_tries() const
	{
		return landingTries;
	}

	void set_landing_tries(int landing_tries)
	{
		landingTries = landing_tries;
	}

	set<Flight> successful_landings() const
	{
		return successfulLandings;
	}

	void set_successful_landings(set<Flight> successful_landings)
	{
		successfulLandings = successful_landings;
	}

	int successful_landings_count() const
	{
		return successfulLandingsCount;
	}

	void set_successful_landings_count(int successful_landings_count)
	{
		successfulLandingsCount = successful_landings_count;
	}
};

