#include "Charset.h"

Charset::Charset(std::string name,double mass,double jumpSpeed,unsigned int identifier)
:_name(name),_identifier(identifier)
{
    _jumpSpeed = jumpSpeed * 0.278;
    _mass = mass * 1000;
}

Charset::~Charset()
{}

Charset::Charset(const Charset& other)
{
    this->_name = other._name;
    this->_mass = other._mass;
    this->_jumpSpeed = other._jumpSpeed;
    this->_identifier = other._identifier;
}
