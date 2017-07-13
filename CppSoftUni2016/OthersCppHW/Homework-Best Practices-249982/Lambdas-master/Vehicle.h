/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

/* 
 * File:   Vehicle.h
 * Author: submarinoff
 *
 * Created on August 1, 2016, 7:10 PM
 */

#ifndef VEHICLE_H
#define VEHICLE_H

#include <string>
#include "Date.h"

using namespace std;

class Vehicle {
public:
    Vehicle();
    Vehicle(const Vehicle& orig);
    virtual ~Vehicle();
    void SetOwner(string owner);
    string GetOwner() const;
    void SetEngineNo(string engineNo);
    string GetEngineNo() const;
    void SetChassisNo(string chassisNo);
    string GetChassisNo() const;
    void SetSeatsNo(short int seatsNo);
    short int GetSeatsNo() const;
    void SetWeight(float weight);
    float GetWeight() const;
    void SetRegNo(string regNo);
    string GetRegNo() const;
    void SetEntryDate(Date* entryDate);
    Date* GetEntryDate() const;
    void SetRegDate(Date* regDate);
    Date* GetRegDate() const;
private:
    string regNo;
    float weight;
    short int seatsNo;
    string chassisNo;
    string engineNo;
    string owner;
    Date* regDate;
    Date* entryDate;
};

#endif /* VEHICLE_H */

