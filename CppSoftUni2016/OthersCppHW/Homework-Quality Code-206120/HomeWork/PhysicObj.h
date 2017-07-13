#include <iostream>
#include <cmath>

#include "Character.h"
#include "Environment.h"

#ifndef PHYSICOBJ_H
#define PHYSICOBJ_H

class PhysicObj : public Character
{
public:
    float h = 0; //height of the jump
    float v0 = 0;// the velocity of the char
    float v1 = 0;// the dead end point, where its always 0
    float g = 0; // gravity
    float t = 0; // time
    float j = 0; // object mass

    PhysicObj();
    inline PhysicObj(Character &aChar, Environment &env)
    {
        v0 = aChar.characterJumpSpeedInKmH;
        g = env.environmentGravity;
        j = aChar.characterMassInKg;
    };

    float calculateMaximumJumpHeightInMeters(); // calculate(object, place)
    float calculateTimeInAir();                 //gets the time in seconds
    bool canItJumpThatHigh(float howHigh);
};

#endif // PHYSICOBJ_H
