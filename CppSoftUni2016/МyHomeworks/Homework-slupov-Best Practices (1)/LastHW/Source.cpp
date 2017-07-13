#include <iostream>
#include "Vehicle.h"
#include <thread>
#include <algorithm>
#include <vector>
#include <string>

using namespace std;

vector<Vehicle> allVehicles;
vector<Vehicle> cars;
vector<Vehicle> trucks;
vector<Vehicle> motorcycles;

void searchVehicle(vector<Vehicle>& someVehicles, string & registrationNumber)
{
	for_each(someVehicles.begin(), someVehicles.end(),[&] (Vehicle v){
		if(v.getRegistrationNumber() == registrationNumber)
		{
			cout << "Registration Num: " << v.getRegistrationNumber() << endl;
			cout << "Weight: " << v.getWeight() << endl;
			cout << "Number of seats: " << v.getNumberOfSeats() << endl;
			cout << "Chasis number: " << v.getChasisNumber() << endl;
			cout << "Engine number: " << v.getEngineNumber() << endl;
			cout << "Owner: " << v.getOwner() << endl;
			cout << "Date of first registration " << v.registrationDate.toString() << endl;
			cout << "Date of local registration " << v.localRegistrationDate.toString() << endl;
			
			return true;
		}

	});
}

int main()
{
	// default objects, TODO: can implement database for more examples
	Vehicle vehicleOne;
	Vehicle vehicleTwo;
	Vehicle vehicleThree;

	vehicleOne.setChasisNumber("12345");
	vehicleOne.setEngineNumber("54321");
	vehicleOne.setNumberOfSeats(4);
	vehicleOne.setOwner("Pesho Peshev");
	vehicleOne.setRegistrationNumber("PB 4321 OP");
	vehicleOne.setType("car");
	vehicleOne.setWeight(312.124);
	vehicleOne.setLocalRegistrationDate(CalendarDate(1, 10, 2013));
	vehicleOne.setRegistrationDate(CalendarDate(1, 10, 2012));
	allVehicles.push_back(vehicleOne);

	vehicleTwo.setChasisNumber("21345");
	vehicleTwo.setEngineNumber("54312");
	vehicleTwo.setNumberOfSeats(6);
	vehicleTwo.setOwner("Gosho Goshev");
	vehicleTwo.setRegistrationNumber("CA 5321 PO");
	vehicleTwo.setType("truck");
	vehicleTwo.setWeight(561.82);
	vehicleTwo.setLocalRegistrationDate(CalendarDate(1,10,2014));
	vehicleTwo.setRegistrationDate(CalendarDate(1, 10, 2011));
	allVehicles.push_back(vehicleTwo);

	vehicleThree.setChasisNumber("31245");
	vehicleThree.setEngineNumber("54213");
	vehicleThree.setNumberOfSeats(2);
	vehicleThree.setOwner("Mihail Mihalchev");
	vehicleThree.setRegistrationNumber("CA 6321 PO");
	vehicleThree.setType("motorcycle");
	vehicleThree.setWeight(561.82);
	vehicleThree.setLocalRegistrationDate(CalendarDate(1, 10, 2015));
	vehicleThree.setRegistrationDate(CalendarDate(1, 10, 2010));
	allVehicles.push_back(vehicleThree);

	for each (Vehicle v in allVehicles)
	{
		if (v.getType() == "car")
		{
			cars.push_back(v);
		}
		else if (v.getType() == "truck")
		{
			trucks.push_back(v);
		}
		else if (v.getType() == "motorcycle")
		{
			motorcycles.push_back(v);
		}
	}

	cout << "Please enter registration number of a vehicle to search: ";
	string registrationNumber;
	getline(cin, registrationNumber);


	thread thr1(searchVehicle,cars, registrationNumber);
	thread thr2(searchVehicle,trucks, registrationNumber);
	thread thr3(searchVehicle,motorcycles, registrationNumber);
	
	thr1.join();
	thr2.join();
	thr3.join();
	
return 0;
}