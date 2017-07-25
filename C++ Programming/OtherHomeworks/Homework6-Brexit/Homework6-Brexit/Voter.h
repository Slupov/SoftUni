#pragma once
#include <iostream>

class Voter
{
public:
	Voter() {};
	Voter(std::string newName, int newAge, char newGender, std::string newCity, std::string newEthnos, short int newVote)
	{
		name = newName;
		age = newAge;
		gender = newGender;
		city = newCity;
		ethnos = newEthnos;
		vote = newVote;
	}

	std::string name;
	int age;
	char gender;
	std::string city;
	std::string ethnos;
	short int vote;

};