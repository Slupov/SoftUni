#include " Enviroment.h"

 Enviroment::Enviroment(unsigned int identifier,std::string name,double gravity)
 :_identifier(identifier),_name(name),_gravity(gravity)
{}

 Enviroment::~ Enviroment()
{}

Enviroment::Enviroment(const Enviroment& other)
{
    this->_identifier = other._identifier;
    this->_name = other._name;
    this->_gravity = other._gravity;
}
