/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

/* 
 * File:   Date.cpp
 * Author: submarinoff
 * 
 * Created on August 3, 2016, 12:35 AM
 */

#include "Date.h"

Date::Date() {
}

Date::Date(int day, int month, int year) {
    this->day = day;
    this->month = month;
    this->year = year;
}

Date::Date(const Date& orig) {
}

Date::~Date() {
}

string Date::toString() {
    return to_string(day) + "." + to_string(month) + "." + to_string(year);
}


