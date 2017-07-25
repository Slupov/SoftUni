/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

/* 
 * File:   Vehicle.cpp
 * Author: submarinoff
 * 
 * Created on August 1, 2016, 7:10 PM
 */

#include "Vehicle.h"

Vehicle::Vehicle() {
}

Vehicle::Vehicle(const Vehicle& orig) {
}

Vehicle::~Vehicle() {
}

void Vehicle::SetOwner(string owner) {
    this->owner = owner;
}

string Vehicle::GetOwner() const {
    return owner;
}

void Vehicle::SetEngineNo(string engineNo) {
    this->engineNo = engineNo;
}

string Vehicle::GetEngineNo() const {
    return engineNo;
}

void Vehicle::SetChassisNo(string chassisNo) {
    this->chassisNo = chassisNo;
}

string Vehicle::GetChassisNo() const {
    return chassisNo;
}

void Vehicle::SetSeatsNo(short int seatsNo) {
    this->seatsNo = seatsNo;
}

short int Vehicle::GetSeatsNo() const {
    return seatsNo;
}

void Vehicle::SetWeight(float weight) {
    this->weight = weight;
}

float Vehicle::GetWeight() const {
    return weight;
}

void Vehicle::SetRegNo(string regNo) {
    this->regNo = regNo;
}

string Vehicle::GetRegNo() const {
    return regNo;
}

void Vehicle::SetEntryDate(Date* entryDate) {
    this->entryDate = entryDate;
}

Date* Vehicle::GetEntryDate() const {
    return entryDate;
}

void Vehicle::SetRegDate(Date* regDate) {
    this->regDate = regDate;
}

Date* Vehicle::GetRegDate() const {
    return regDate;
}

