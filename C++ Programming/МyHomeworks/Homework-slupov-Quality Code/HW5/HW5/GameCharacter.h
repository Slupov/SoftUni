#pragma once
#include <iostream>
#include <string>
using namespace std;

class GameCharacter
{
private:
	float massKg;
public:
	string name;
	unsigned int identifier;

	float getMassInKg();
	double jumpSpeed; // in km/h

	void setJumpSpeed(double newJumpSpeed);
	void setMassInKG(float newMass);
	double setJumpSpeed();
};