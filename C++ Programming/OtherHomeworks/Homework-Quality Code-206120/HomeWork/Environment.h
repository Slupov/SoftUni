#include <iostream>

#ifndef ENVIRONMENT_H
#define ENVIRONMENT_H

class Environment
{
public:
    std::string environmentName;
    unsigned int environmentId;
    float environmentGravity; //in m/s2

    Environment();
    inline Environment(std::string name, unsigned int id, float gravity) :
        environmentName(name), environmentId(id), environmentGravity(gravity) {}
    virtual ~Environment() {return;};
};

#endif // ENVIRONMENT_H
