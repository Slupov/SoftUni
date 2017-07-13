#include <iostream>
#include <thread>
#include <vector>
#include "DataStorage.h"
#include "Vehicles.h"
#include "Date.h"

using namespace std;

vector<string> menu
{
	"Press E to enter the searched number;\n",
	"Press N to enter a new vehicle;\n",
	"Press Q to quit;\n",
	"Please enter the code or option:\n",
};

enum Options
{
	searchNumber = 'E',
	newVehicle = 'N',
	quit = 'Q',
};

void printMenu()
{
	for (auto &i : menu)
	{
		cout << i;
	}
}

int main()
{
	string userInput;
	string regNumber;
	string vehicleType;

	DataStorage trucksRegister = DataStorage();
	DataStorage carsRegister = DataStorage();
	DataStorage motorcyclesRegister = DataStorage();

	Date regDate = Date(12, 12, 1999, 12, 3, 2005);

	Vehicle carHondaCivic = Vehicle("AB1212FG", 1.2f, 2, "152485124", "D14A400192", "Nedka Taskova", regDate);
	Vehicle carFordEscort = Vehicle("CD1523KK", 1.2f, 4, "152485124", "D14A400192", "Nedka Taskova", regDate);
	Vehicle carBMV = Vehicle("CC8569LM", 1.2f, 4, "152485124", "D14A400192", "Nedka Taskova", regDate);
	Vehicle carMercedes = Vehicle("XC4578CC", 1.2f, 4, "152485124", "D14A400192", "Nedka Taskova", regDate);
	Vehicle carLamborghini = Vehicle("SD4796DD", 1.2f, 2, "152485124", "D14A400192", "Nedka Taskova", regDate);

	Vehicle truck1 = Vehicle("AB4578FG", 5.2f, 2, "152485124", "D14A400192", "Nedka Taskova", regDate);
	Vehicle truck2 = Vehicle("XC1278FF", 13.5f, 3, "152485124", "D14A400192", "Nedka Taskova", regDate);
	Vehicle truck3 = Vehicle("AS8614VF", 4.3f, 2, "152485124", "D14A400192", "Nedka Taskova", regDate);
	Vehicle truck4 = Vehicle("CV4777VV", 12.6f, 3, "152485124", "D14A400192", "Nedka Taskova", regDate);
	Vehicle truck5 = Vehicle("SD9645DD", 2.6f, 2, "152485124", "D14A400192", "Nedka Taskova", regDate);

	Vehicle motorcycle1 = Vehicle("CX5841KL", 0.8f, 2, "152485124", "D14A400192", "Nedka Taskova", regDate);
	Vehicle motorcycle2 = Vehicle("VN4972MK", 0.36f, 3, "152485124", "D14A400192", "Nedka Taskova", regDate);
	Vehicle motorcycle3 = Vehicle("CV4999NN", 0.023f, 2, "152485124", "D14A400192", "Nedka Taskova", regDate);
	Vehicle motorcycle4 = Vehicle("XA9999XX", 0.56f, 3, "152485124", "D14A400192", "Nedka Taskova", regDate);
	Vehicle motorcycle5 = Vehicle("AA1111AA", 0.22f, 2, "152485124", "D14A400192", "Nedka Taskova", regDate);
	
	carsRegister.addVehicle(carHondaCivic);
	carsRegister.addVehicle(carFordEscort);
	carsRegister.addVehicle(carBMV);
	carsRegister.addVehicle(carMercedes);
	carsRegister.addVehicle(carLamborghini);

	trucksRegister.addVehicle(truck1);
	trucksRegister.addVehicle(truck2);
	trucksRegister.addVehicle(truck3);
	trucksRegister.addVehicle(truck4);
	trucksRegister.addVehicle(truck5);

	trucksRegister.addVehicle(motorcycle1);
	trucksRegister.addVehicle(motorcycle2);
	trucksRegister.addVehicle(motorcycle3);
	trucksRegister.addVehicle(motorcycle4);
	trucksRegister.addVehicle(motorcycle5);

	printMenu();
	cin >> userInput;

	while (userInput[0] != 'Q')
	{
		switch (userInput[0])
		{
		case searchNumber:
			cin >> regNumber;
			cin.ignore();
			carsRegister.ready = false;

			while (!carsRegister.ready)
			{
				std::thread carThread(&DataStorage::searchedNumber, &carsRegister, regNumber);
				std::thread truckThread(&DataStorage::searchedNumber, &trucksRegister, regNumber);
				std::thread motorcycleThread(&DataStorage::searchedNumber, &motorcyclesRegister, regNumber);
				carThread.join();
				truckThread.join();
				motorcycleThread.join();
			}
			break;

		case newVehicle:
			cout << "Please, enter the type of vehicle: car, truck or motorcycle: ";
			cin >> vehicleType;
			if (vehicleType == "car") { carsRegister.addVehicle(); }
			else if (vehicleType == "truck") { carsRegister.addVehicle(); }
			else if (vehicleType == "motorcycle") { carsRegister.addVehicle(); }
			break;

		default:
			cout << "It is not valid command or item code!\n";
			break;
		}
		
		printMenu();
		cin >> userInput;
		cin.ignore();
	}

	return 0;
}

//Homework 9
//
//Make a system for managing information for the motor vehicles in Bulgaria.
//The system shall have different containers for cars, trucks, motorcycles.The class describing a vehicle must have the following members :
//-Registration number(string)
//- Weight(float in tones)
//- Number of seats(short int)
//- Chassis number(string)
//- Engine number(string)
//- Owner(string)
//- Date of first registration(custom class Date) – when the car was firstly registered
//- Date of registration in country(custom class Date) – when the car was registered with its current registration
//
//And Functions :
//-Getter for all of the information
//
//The system shall support multithread search for each container(you start searching for a vehicle with a registration number and the program initialize search in each container on a different thread).
//
//Lambda expressions shall be used in the software for the search(consider using for_each function).
//Lambda expressions shall be used in the software for displaying the information(the function must look like : searchForACarWithRegistrationNumber(string registrationNumber, void aLambdaExpressionToBeExecutedWhenFound())
//
//	A simple example of using the software : (<< -Output, >> -Input)
//
//	<< Please enter registration number of a vehicle to search
//	>> A2273MM
//	<< Searching
//	<< A2273MM
//	<< Weight: 1.0 t
//	<< Number of seats : 5
//	<< Chassis number : 123123123123123
//	<< Engine number : D14A400192
//	<< Owner : Martin Kuvandzhiev
//	<< Date of first registration : 29.07.2000
//	<< Date of registration in country : 14.03.2014
//
//
