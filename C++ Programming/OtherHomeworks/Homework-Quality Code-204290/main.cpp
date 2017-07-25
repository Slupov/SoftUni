#include <iostream>
#include "Jump.h"

using namespace std;

int main()
{
    Enviroment env(1,"Earth",9.8);
    Charset charset("Dragon",10,30.5,2);
    Jump moveJump(charset,env);
    cout << moveJump.isCapableOfJumping(0.234) << endl;
    cout << moveJump.maxJumpingHeight() << endl;
    return 0;
}
