#ifndef  ENVIROMENT_H
#define  ENVIROMENT_H

#include <string>

class  Enviroment
{
    public:
        Enviroment(unsigned int identifier,std::string name,double gravity);
        virtual ~ Enviroment();
        Enviroment(const Enviroment& other);
        unsigned int Get_identifier() { return _identifier; }
        void Set_identifier(unsigned int val) { _identifier = val; }
        std::string Get_name() { return _name; }
        void Set_name(std::string val) { _name = val; }
        double Get_gravity() { return _gravity; }
        void Set_gravity(double val) { _gravity = val; }
    protected:
    private:
        unsigned int _identifier;
        std::string _name;
        double _gravity;
};

#endif //  ENVIROMENT_H
