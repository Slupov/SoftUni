#include "Flight.h"

void Flight::toString()
{
	printf("Mission name: %s \nRocket name: %s \nWeight: %lf \n Flight time: %d \nLand success: %d \n", this->mission_name(),
	this->rocket_name(),this->weight1(),this->flight_time(),this->land_success());
}

Flight::Flight()
{
}


Flight::~Flight()
{
}
