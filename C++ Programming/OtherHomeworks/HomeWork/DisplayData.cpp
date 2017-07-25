#include "DisplayData.h"

void DisplayData::displayData(Environment &env, PhysicObj &pObj, Character &aChar, float howHigh)
{
    std::cout << "Gravity on the planet " << env.environmentName << " is: "
        << env.environmentGravity << " m/s^2 " << std::endl;
    std::cout << aChar.name << ", with weight of "
        << aChar.characterMassInKg
        << " kg would jump as high as "
        << pObj.calculateMaximumJumpHeightInMeters()
        << " meters." << std::endl;

    std::cout << pObj.calculateMaximumJumpHeightInMeters() << std::endl;

    std::cout << pObj.calculateTimeInAir() << std::endl;
    std::cout << pObj.canItJumpThatHigh(howHigh) << std::endl;
}