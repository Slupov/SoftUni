//Created on 07-AUG-2016 by Stoyan Lupov (slupov) - the man who cannot fix error C2664 in his code 
#include <iostream>
#include "LocationUtility.h"
#include <set>
#include "Location.h"
#include "FlightUtility.h"
#include "Functions.h"
#include <memory>
#include <thread>

using namespace std;

int main()
{
	
	mutex outputMutex;

	//sets are sortedd
	set<shared_ptr<Location>> locations;
	set<shared_ptr<Flight>> flights;

	/*std::set<shared_ptr<Flight>>::iterator itStart;
	std::set<shared_ptr<Flight>>::iterator itEnd;
	int iterRange;*/


	//generating random flights and locations using the utility headers
	//for data populating purposes
	generateFlights(flights,20);
	generateLocations(locations,20);
	
	//there is only one container (flights)
	//TO DO: in order to use threads split flights into two halves (ran out of time)
	//set<shared_ptr<Flight>> firstFlightsHalf;
	//set<shared_ptr<Flight>> secondFlightsHalf;


	thread thr1(searchFlight, flights,outputMutex);
	thread thr2(addFlight, flights,outputMutex);
	//thread thr2(searchFlight, secondFlightsHalf,outputMutex); (ran out of time)

	thr1.join();
	thr2.join();
	//thr2.join();

	return 0;
}