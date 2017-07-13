#ifndef CHARSET_H
#define CHARSET_H
#include <string>

class Charset
{
    public:
        Charset(std::string name,double mass,double jumpSpeed,unsigned int indentifier);
        virtual ~Charset();
        Charset(const Charset& other);
        double getMass()const {return _mass;}
        double getJumpSpeed()const {return _jumpSpeed;}
    protected:
    private:
        std::string _name;
        double _mass;
        double _jumpSpeed;
        unsigned int _identifier;
    };

#endif // CHARSET_H
