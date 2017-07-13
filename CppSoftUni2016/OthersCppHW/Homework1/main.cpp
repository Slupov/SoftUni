//There is no indication of what the differences between types of
//vehcles should be, except in qualification. Even if different types
//of vehicles were implemented, there would still be no need of 
//templates, since it can be done by simply using polymorphism.
//On account of that, I have used multithreading to search
//through different parts of a single vehicle vector.

#include <iostream>
#include <string>
#include <vector>
#include <thread>
#include <mutex>
#include <algorithm>
#include "Vehicle.h"
#include "Utility.h"

void findRegistNumber(std::string, std::vector<Vehicle>&, 
		std::vector<Vehicle>::iterator, std::vector<Vehicle>::iterator, std::mutex&, void (Vehicle));


int main()
{
	std::string numberToSearch;
	std::mutex outputMutex;
	std::vector<Vehicle> vehicles;
	std::vector<Vehicle>::iterator itStart;
	std::vector<Vehicle>::iterator itEnd;
	Vehicle vehicle;
	int iterRange;

	generateVehicles(vehicles, 200);					//generate some vehicles

	vehicle.setRegistrationNumber("A1234BC");			//generate an easy to find vehicle
	vehicle.setChassisNumber("154378549032561");
	vehicle.setEngineNumber("1H24D921A");
	vehicle.setOwner("Desislava Stoimenova");
	vehicle.setWeight(1.2);
	vehicle.setSeatsCount(4);
	vehicle.setFirstRegistDate(21, 4, 2010);
	vehicle.setCountryRegistDate(12, 9, 2013);

	vehicles.push_back(vehicle);

	auto displayLambda = [](Vehicle vehicle)
	{
		std::cout << vehicle.getRegistrationNumber() << "\n";
		std::cout << "Weight: " << vehicle.getWeight() << "\n";
		std::cout << "Number of seats: " << vehicle.getSeatsCount() << "\n";
		std::cout << "Chassis number: " << vehicle.getChassisNumber() << "\n";
		std::cout << "Engine number: " << vehicle.getEngineNumber() << "\n";
		std::cout << "Owner: " << vehicle.getOwner() << "\n";
		std::cout << "Date of first registration: ";
		vehicle.getFirstRegistDate();
		std::cout << "\nDate of registration in country: ";
		vehicle.getCountryRegistDate();
		std::cout << std::endl;
	};

	std::cout << "Please enter registration number of a vehicle to search\n";
	std::cin >> numberToSearch;
	
	iterRange = vehicles.size() / 3;				//break up the vector in 3 ranges for 3 threads

	itStart = vehicles.begin();
	itEnd = itStart + iterRange;

	std::thread thread1 (findRegistNumber, numberToSearch, std::ref(vehicles),
		itStart, itEnd, std::ref(outputMutex), displayLambda);

	itStart = itEnd;
	itEnd += iterRange;

	std::thread thread2 (findRegistNumber, numberToSearch, std::ref(vehicles),
		itStart, itEnd, std::ref(outputMutex), displayLambda);

	itStart = itEnd;
	itEnd = vehicles.end();

	std::thread thread3 (findRegistNumber, numberToSearch, std::ref(vehicles),
		itStart, itEnd, std::ref(outputMutex), displayLambda);


	thread1.join();
	thread2.join();
	thread3.join();

	return 0;
}


///////////////////////////////////
void findRegistNumber(std::string _registNumber, std::vector<Vehicle> &_vehicles,
		std::vector<Vehicle>::iterator start, std::vector<Vehicle>::iterator end, 
		std::mutex &_mutex, void displayLambda(Vehicle))
{

	std::vector<Vehicle>::iterator vehicleIter;
	std::thread::id thread_id = std::this_thread::get_id();

	_mutex.lock();
		std::cout << "Thread " << thread_id << " searching\n";
	_mutex.unlock();

	auto searchLambda = [&] (Vehicle vehicle)
	{	
		if (vehicle.getRegistrationNumber() == _registNumber)
		{
			_mutex.lock();
				std::cout << "Thread " << thread_id 
					<< " found the registration number\n" << std::endl;
				displayLambda(vehicle);
			_mutex.unlock();
		}
	};

	for_each(start, end, searchLambda);
}