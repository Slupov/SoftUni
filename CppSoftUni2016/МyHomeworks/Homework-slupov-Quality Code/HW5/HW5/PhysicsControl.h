#pragma once

#include <iostream>
#include "GameCharacter.h"
#include "Environment.h"


class PhysicsControl
{
	Environment environment;
public:
	PhysicsControl() {};
	PhysicsControl(Environment newEnvironment) :
		environment(newEnvironment) {};

	float maximumJumpHeight(const GameCharacter &aCharacter, const Environment &environment);
	float timeOfJump(const GameCharacter &aCharacter, const Environment &Environment);
	bool jumpingAtHeightCapability(const float maxJumpHeight, float height);
};