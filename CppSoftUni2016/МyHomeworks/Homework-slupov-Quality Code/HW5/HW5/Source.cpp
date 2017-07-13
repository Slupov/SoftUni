#include "Environment.h"
#include "GameCharacter.h"
#include "PhysicsControl.h"
#include <iostream>
#include <string>

using namespace std;

#define EARTH_GRAVITY 9.81
#define MOON_GRAVITY 1.622
#define JUMP_HEIGHT_GOAL 2
int main()
{
	PhysicsControl currentGamePhysics;

	GameCharacter myCharacter;
	myCharacter.setMassInKG(70);
	myCharacter.setJumpSpeed(5);

	Environment moonEnvironment = Environment(MOON_GRAVITY);
	moonEnvironment.name = "Moon";
	moonEnvironment.identifier = 2;

	Environment earthEnvironment = Environment(EARTH_GRAVITY);
	earthEnvironment.name = "Earth";
	earthEnvironment.identifier = 1;

	Environment mainEnvironment = earthEnvironment; //an easy way to change the environment from a single line

	float maximumJumpHeight = currentGamePhysics.maximumJumpHeight(myCharacter, mainEnvironment);
	float jumpTime = currentGamePhysics.timeOfJump(myCharacter, mainEnvironment);
	bool jumpCapability = currentGamePhysics.jumpingAtHeightCapability(maximumJumpHeight, JUMP_HEIGHT_GOAL);

	cout << "Maximum jump height: " << maximumJumpHeight << endl;
	cout << "Time of jump: " << jumpTime << endl;
	cout << "Is the game character capable of jumping at "<< JUMP_HEIGHT_GOAL << " meters height: " << boolalpha << jumpCapability << endl;



	system("pause");
	return 0;
}