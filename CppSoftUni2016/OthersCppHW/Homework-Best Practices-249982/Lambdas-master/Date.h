/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

/* 
 * File:   Date.h
 * Author: submarinoff
 *
 * Created on August 3, 2016, 12:35 AM
 */

#ifndef DATE_H
#define DATE_H

#include <string>

using namespace std;

class Date {
public:
    Date();
    Date(int day, int month, int year);
    Date(const Date& orig);
    virtual ~Date();
    
    string toString();
private:
    int day;
    int month;
    int year;
};

#endif /* DATE_H */

