#include "PhysicsControl.h"
#include "GameCharacter.h"
#include "Environment.h"
#include <iostream>

float PhysicsControl::maximumJumpHeight(const GameCharacter &aCharacter, const Environment &environment)
{
	//height in meters
	float height = (aCharacter.jumpSpeed/3.6)*(aCharacter.jumpSpeed / 3.6) / (2*environment.gravity); 
	return height;
}

float PhysicsControl::timeOfJump(const GameCharacter &aCharacter, const Environment &environment)
{
	//time in seconds
	float time = (aCharacter.jumpSpeed/3.6)/environment.gravity; 
	return time;
}

bool PhysicsControl::jumpingAtHeightCapability(const float maxJumpHeight, float heightToJump)
{
	//height in meters
	if (maxJumpHeight < heightToJump)
	{
		return false;
	}
	return true;
}