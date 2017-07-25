#include <iostream>

#include "Character.h"
#include "Environment.h"
#include "PhysicObj.h"
#include "DisplayData.h"

using namespace std;

#define EARTH_GRAVITY 9.81
#define MOON_GRAVITY 1.62

/** * I tried to follow all the OOP presented in the course so far, but one thing I didn't do - private variables,
        because it will just complicate the code a lot more, with getters and setters, for something, I think it's
        unneccesery.
    * I followed the self-documenting naming convention from the lecture as much as possible.
    * My physics formulas are not perfect and probably incorect.
    * Please, consider constructive criticism on all the aspects of the code, and correct me if I am wrong somewhere.

        Thank you !
    */

int main()
{
    float howHigh = 0.20; // 20 cm, height of a step

    Character clarence;
    clarence.name = "Clarence";
    clarence.id = 10;
    clarence.characterJumpSpeedInKmH = 4;
    clarence.characterMassInKg = 60;

    Environment earth = Environment("Earth", 213, EARTH_GRAVITY);
    Environment moon = Environment("Moon", 214, MOON_GRAVITY);

    PhysicObj earthClar = PhysicObj(clarence, earth);
    PhysicObj moonClar = PhysicObj(clarence, moon);

    DisplayData dData;

    dData.displayData(earth, earthClar, clarence, howHigh);

    return 0;
}
