#include "Jump.h"

Jump::Jump(Charset charset,Enviroment enviroment)
:_charset(charset),_enviroment(enviroment)
{}

Jump::~Jump()
{}

double Jump::maxJumpingHeight()
{
    return  (4*(_charset.getJumpSpeed() * _charset.getJumpSpeed()))/(2*_enviroment.Get_gravity());
}
bool  Jump::isCapableOfJumping(double height)
{
    if(height > this->maxJumpingHeight())
        return false;
    return true;
}
