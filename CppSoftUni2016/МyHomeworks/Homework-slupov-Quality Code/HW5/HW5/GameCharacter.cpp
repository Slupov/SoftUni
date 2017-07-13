#include <iostream>
#include "GameCharacter.h"

void GameCharacter :: setMassInKG(float newMass)
{
	this->massKg = newMass;
}
float GameCharacter:: getMassInKg()
{
	return this->massKg;
}
void GameCharacter::setJumpSpeed(double newJumpSpeed)
{
	this->jumpSpeed = newJumpSpeed;
}
double GameCharacter::setJumpSpeed()
{
	return this->jumpSpeed;
}