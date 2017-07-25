#include <iostream>

#include "Character.h"
#include "Environment.h"
#include "Object.h"
#include "PhysicObj.h"

#ifndef DISPLAYDATA_H
#define DISPLAYDATA_H

class DisplayData
{
public:
    void displayData(Environment &env, PhysicObj &pObj, Character &aChar, float howHigh);
};

#endif // DISPLAYDATA_H
