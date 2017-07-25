#pragma once
#include "Voter.h"
#include <iostream>
#include <map>

class Results
{
public:
	Results() {};
	Results(int newStay, int newLeave)
	{
		this->votesForStay = newStay;
		this->votesForLeave = newLeave;
	}

	int votesForStay;
	int votesForLeave;
	std::map<std::string, int> nameStayResults;
	std::map<char, int> genderStayResults;
	std::map<std::string, int> ethnosStayResults;
	std::map<std::string, int> cityStayResults;
	std::map<int, int> ageStayResults;

	std::map<std::string, int> nameLeaveResults;
	std::map<char, int> genderLeaveResults;
	std::map<std::string, int> ethnosLeaveResults;
	std::map<std::string, int> cityLeaveResults;
	std::map<int, int> ageLeaveResults;
	
	void resultsInPercent(int stayVotes, int leaveVotes);
	void resultsInNumbers(int stayVotes, int leaveVotes);
	void resultsByName(std::string searchedName);
	void resultsByAge(int searchedAge);
	void resultsByEthnos(std::string searchedEthnos);
	void resultsByGender(char searchedGender);
	void resultsByCity(std::string searchedCity);

	void addVotes(Voter aVoter);

};