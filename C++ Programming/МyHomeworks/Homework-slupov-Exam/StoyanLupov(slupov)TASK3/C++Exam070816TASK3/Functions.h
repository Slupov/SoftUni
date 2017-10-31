#pragma once
#include <string>
#include <set>
#include "Flight.h"
#include <algorithm>
#include <memory>
#include <mutex>
using namespace std;

void inline searchFlight(std::set<shared_ptr<Flight>>& flights, mutex _mutex)
{
	std::thread::id thread_id = std::this_thread::get_id();

	_mutex.lock();
	cout << "Please enter the name of the flight you're trying to search: ";
	string name;
	cin >> name;
	std::cout << "Thread " << thread_id << " searching\n";
	_mutex.unlock();
	
	auto searchLambda = [&] (shared_ptr<Flight> f)
	{
		if (f->mission_name() == name)
		{
			_mutex.lock();
			cout << "Searched flight is :" << endl;
			f->toString();
			_mutex.unlock();
		}
	};

	for_each(flights.begin(), flights.end(),searchLambda);
};


void inline addFlight(set<shared_ptr<Flight>>& flights, mutex _mutex)
{
	string str = "";
	shared_ptr<Flight> flightToAdd;

	_mutex.lock();
	cout << "Please add info" << endl;

	cout << "Mission name: ";
	cin >> str;
	flightToAdd->set_mission_name(str);

	cout << "Rocket name: ";
	cin >> str;
	flightToAdd->set_rocket_name(str);

	// TO DO: make more user friendly but aint nobody got time fo dat now
	long long flightTime;
	cout << "Flight time in seconds: ";
	cin >> flightTime;
	_mutex.unlock();


	//TO DO: implement other properties but you get the idea

	flights.insert(flightToAdd);

};