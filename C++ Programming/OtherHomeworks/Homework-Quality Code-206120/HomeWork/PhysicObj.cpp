#include "PhysicObj.h"

float PhysicObj::calculateMaximumJumpHeightInMeters()
{
    h = std::pow(v0, 2) / (2 * g);//height of the jump, assuming this is the correct formula

    return h;
}


float PhysicObj::calculateTimeInAir()
{
    float timeInAir = 0; // no one told me how
    float freeFall = 5; // work in progress, still figuring out how to find that

    timeInAir = h - freeFall;

    return timeInAir;
}

bool PhysicObj::canItJumpThatHigh(float howHigh)
{
    bool canItJump = false;
    float maxJump = calculateMaximumJumpHeightInMeters();

    if(maxJump >= howHigh)
    {
        canItJump = true;
    }

    return canItJump;
}