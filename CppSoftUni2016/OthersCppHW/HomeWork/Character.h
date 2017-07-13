#include <iostream>
#include "Object.h"

#ifndef CHARACTER_H
#define CHARACTER_H

class Character: public Object
{
public:
    float characterMassInKg;
    float characterJumpSpeedInKmH;
};

#endif // CHARACTER_H
