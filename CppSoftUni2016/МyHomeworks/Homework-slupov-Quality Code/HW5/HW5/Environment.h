#pragma once
#include <iostream>
#include <string>
#include "GameCharacter.h"
using namespace std;

class Environment : public GameCharacter
{
public:
	double gravity; // in m/s^2

	Environment() {};
	Environment(double newGravity)
	{
		gravity = newGravity;
	}
};