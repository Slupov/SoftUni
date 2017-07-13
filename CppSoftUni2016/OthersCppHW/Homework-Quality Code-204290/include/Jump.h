#include "Charset.h"
#include " Enviroment.h"

#ifndef JUMP_H
#define JUMP_H

class Jump
{
    public:
        Jump(Charset charset,Enviroment enviroment);
        virtual ~Jump();
        Jump(const Jump& other);
        Charset Get_charset() { return _charset; }
        void Set_charset(Charset val) { _charset = val; }
        Enviroment Get_enviroment() { return _enviroment; }
        void Set_enviroment(Enviroment val) { _enviroment = val; }
        double maxJumpingHeight();
        bool isCapableOfJumping(double height);
    protected:
    private:
        Charset _charset;
        Enviroment _enviroment;
};

#endif // JUMP_H
