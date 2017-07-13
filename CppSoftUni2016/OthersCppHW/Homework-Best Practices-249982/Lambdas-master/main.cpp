
#include <iostream>
#include <algorithm>
#include <vector>
#include <string>
#include <functional>
#include <thread>
#include <mutex>
#include "Vehicle.h"

typedef Vehicle* VEHICLE;

using namespace std;

vector<VEHICLE> cars;
vector<VEHICLE> trucks;
vector<VEHICLE> motorcycles;

mutex consoleMutex;


function<void (VEHICLE)> lambda = [&](VEHICLE vehicle){
    consoleMutex.lock();
    cout << "Chassis No.: " << vehicle->GetChassisNo() << endl;
    cout << "Engine No.: "<< vehicle->GetEngineNo() << endl;
    cout << "Registration No.: " << vehicle->GetRegNo() << endl;
    cout << "Weight: "<< vehicle->GetWeight() << " tons" << endl;
    cout << "Owner: "<< vehicle->GetOwner() << endl;
    cout << "Registration date: " << vehicle->GetRegDate()->toString() << endl;
    cout << "Date of entry: " << vehicle->GetEntryDate()->toString() << endl;
    cout << "<------------------------->" << endl;
    consoleMutex.unlock();
};

void printCompliant(vector<VEHICLE> vehicles, string number, function<void (VEHICLE)> printVehicle){
    for_each(vehicles.begin(), vehicles.end(), [number, printVehicle](VEHICLE vehicle){
        if(vehicle->GetRegNo() == number){
            printVehicle(vehicle);
        }
    });
}

void searchForACarWithRegistrationNumber(string registrationNumber, function<void (VEHICLE)> printVehicle){
    thread carsThread(printCompliant, cars, registrationNumber, printVehicle);
    thread trucksThread(printCompliant, trucks, registrationNumber, printVehicle);
    thread motosThread(printCompliant, motorcycles, registrationNumber, printVehicle);
    carsThread.join();
    trucksThread.join();
    motosThread.join();
}

void populateContainers() {
    VEHICLE car = new Vehicle();
    VEHICLE truck = new Vehicle();
    VEHICLE hog = new Vehicle();
    car->SetChassisNo("123123213");
    car->SetEngineNo("12332213");
    car->SetRegNo("Something");
    car->SetSeatsNo(5);
    car->SetWeight(2);
    car->SetOwner("John Doe");
    car->SetRegDate(new Date(12, 12, 1992));
    car->SetEntryDate(new Date(12, 12, 2016));
    cars.push_back(car);
    truck->SetChassisNo("3333333333");
    truck->SetEngineNo("143236325253");
    truck->SetRegNo("Something");
    truck->SetSeatsNo(5);
    truck->SetWeight(2);
    truck->SetOwner("Chuck Finley");
    truck->SetRegDate(new Date(12, 12, 1992));
    truck->SetEntryDate(new Date(12, 12, 2016));
    trucks.push_back(truck);
    hog->SetChassisNo("123123213");
    hog->SetEngineNo("12332213");
    hog->SetRegNo("Something");
    hog->SetSeatsNo(5);
    hog->SetWeight(2);
    hog->SetOwner("Paul Tutel, Sr.");
    hog->SetRegDate(new Date(13, 12, 1992));
    hog->SetEntryDate(new Date(16, 12, 2016));
    motorcycles.push_back(hog);
}

int main(int argc, char** argv) {
    string regNo;
    populateContainers();
    while(true){
        cout << "Enter registration number: ";
        cin >> regNo;
        if(regNo == "exit"){
            break;
        }
        searchForACarWithRegistrationNumber(regNo, lambda);
    }

    return 0;
}

