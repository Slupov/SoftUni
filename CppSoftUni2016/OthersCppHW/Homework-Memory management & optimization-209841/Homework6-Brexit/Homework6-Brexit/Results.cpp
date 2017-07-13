#include <iostream>
#include "Results.h"

void Results::resultsInPercent(int stayVotes, int leaveVotes)
{
	float resultsForStayInPercent = (stayVotes * 100) / (stayVotes + leaveVotes);
	float resultsForLeaveInPercent = (leaveVotes * 100) / (stayVotes + leaveVotes);
	std::cout << "Votes for stay: " << resultsForStayInPercent << " % " << std::endl;
	std::cout << "Votes for leave: " << resultsForLeaveInPercent << " % " << std::endl;
}

void Results::resultsInNumbers(int stayVotes, int leaveVotes)
{
	std::cout << "Votes for stay: " << stayVotes << std::endl;
	std::cout << "Votes for leave: " << leaveVotes << std::endl;
}

void Results::resultsByName(std::string searchedName)
{
	std::map<std::string, int>::iterator it1 = nameStayResults.find(searchedName);
	if (it1 != nameStayResults.end())
		std::cout << "Stay: " << it1->second << std::endl;
	else
		std::cout << "Stay: 0" << std::endl;
	std::map<std::string, int>::iterator it2 = nameLeaveResults.find(searchedName);
	if (it2 != nameLeaveResults.end())
		std::cout << "Leave: " << it2->second << std::endl;
	else
		std::cout << "Leave: 0" << std::endl;
}

void Results::resultsByGender(char searchedGender)
{
	std::map<char, int>::iterator it1 = genderStayResults.find(searchedGender);
	if (it1 != genderStayResults.end())
		std::cout << "Stay: " << it1->second << std::endl;
	else
		std::cout << "Stay: 0" << std::endl;
	std::map<char, int>::iterator it2 = genderLeaveResults.find(searchedGender);
	if (it2 != genderLeaveResults.end())
		std::cout << "Leave: " << it2->second << std::endl;
	else
		std::cout << "Leave: 0" << std::endl;
}

void Results::resultsByAge(int searchedAge)
{
	std::map<int, int>::iterator it1 = ageStayResults.find(searchedAge);
	if (it1 != ageStayResults.end())
		std::cout << "Stay: " << it1->second << std::endl;
	else
		std::cout << "Stay: 0" << std::endl;
	std::map<int, int>::iterator it2 = ageLeaveResults.find(searchedAge);
	if (it2 != ageLeaveResults.end())
		std::cout << "Leave: " << it2->second << std::endl;
	else
		std::cout << "Leave: 0" << std::endl;
}

void Results::resultsByEthnos(std::string searchedEthnos)
{
	std::map<std::string, int>::iterator it1 = ethnosStayResults.find(searchedEthnos);
	if (it1 != ethnosStayResults.end())
		std::cout << "Stay: " << it1->second << std::endl;
	else
		std::cout << "Stay: 0" << std::endl;
	std::map<std::string, int>::iterator it2 = ethnosLeaveResults.find(searchedEthnos);
	if (it2 != ethnosLeaveResults.end())
		std::cout << "Leave: " << it2->second << std::endl;
	else
		std::cout << "Leave: 0" << std::endl;
}

void Results::resultsByCity(std::string searchedCity)
{
	std::map<std::string, int>::iterator it1 = cityStayResults.find(searchedCity);
	if (it1 != cityStayResults.end())
		std::cout << "Stay: " << it1->second << std::endl;
	else
		std::cout << "Stay: 0" << std::endl;
	std::map<std::string, int>::iterator it2 = cityLeaveResults.find(searchedCity);
	if (it2 != cityLeaveResults.end())
		std::cout << "Leave: " << it2->second << std::endl;
	else
		std::cout << "Leave: 0" << std::endl;
}

void Results::addVotes(Voter aVoter)
{
	if (aVoter.vote == 0)
	{
		votesForLeave++;

		if (nameLeaveResults.find(aVoter.name) == nameLeaveResults.end())
		{
			nameLeaveResults.insert(std::pair<std::string, int>(aVoter.name, 1));
		}
		else
		{
			std::map<std::string, int>::iterator it1 = nameLeaveResults.find(aVoter.name);
			it1->second++;
		}

		if (ageLeaveResults.find(aVoter.age) == ageLeaveResults.end())
		{
			ageLeaveResults.insert(std::pair<int, int>(aVoter.age, 1));
		}
		else
		{
			std::map<int, int>::iterator it1 = ageLeaveResults.find(aVoter.age);
			it1->second++;
		}

		if (ethnosLeaveResults.find(aVoter.ethnos) == ethnosLeaveResults.end())
		{
			ethnosLeaveResults.insert(std::pair<std::string, int>(aVoter.ethnos, 1));
		}
		else
		{
			std::map<std::string, int>::iterator it1 = ethnosLeaveResults.find(aVoter.ethnos);
			it1->second++;
		}

		if (cityLeaveResults.find(aVoter.ethnos) == cityLeaveResults.end())
		{
			cityLeaveResults.insert(std::pair<std::string, int>(aVoter.city, 1));
		}
		else
		{
			std::map<std::string, int>::iterator it1 = cityLeaveResults.find(aVoter.city);
			it1->second++;
		}

		if (genderLeaveResults.find(aVoter.gender) == genderLeaveResults.end())
		{
			genderLeaveResults.insert(std::pair<char, int>(aVoter.gender, 1));
		}
		else
		{
			std::map<char, int>::iterator it1 = genderLeaveResults.find(aVoter.gender);
			it1->second++;
		}
	}
	else
	{
		votesForStay++;

		if (nameStayResults.find(aVoter.name) == nameStayResults.end())
		{
			nameStayResults.insert(std::pair<std::string, int>(aVoter.name, 1));
		}
		else
		{
			std::map<std::string, int>::iterator it1 = nameStayResults.find(aVoter.name);
			it1->second++;
		}

		if (ageStayResults.find(aVoter.age) == ageStayResults.end())
		{
			ageStayResults.insert(std::pair<int, int>(aVoter.age, 1));
		}
		else
		{
			std::map<int, int>::iterator it1 = ageStayResults.find(aVoter.age);
			it1->second++;
		}

		if (ethnosStayResults.find(aVoter.ethnos) == ethnosStayResults.end())
		{
			ethnosStayResults.insert(std::pair<std::string, int>(aVoter.ethnos, 1));
		}
		else
		{
			std::map<std::string, int>::iterator it1 = ethnosStayResults.find(aVoter.ethnos);
			it1->second++;
		}

		if (cityStayResults.find(aVoter.ethnos) == cityStayResults.end())
		{
			cityStayResults.insert(std::pair<std::string, int>(aVoter.city, 1));
		}
		else
		{
			std::map<std::string, int>::iterator it1 = cityStayResults.find(aVoter.city);
			it1->second++;
		}

		if (genderStayResults.find(aVoter.gender) == genderStayResults.end())
		{
			genderStayResults.insert(std::pair<char, int>(aVoter.gender, 1));
		}
		else
		{
			std::map<char, int>::iterator it1 = genderStayResults.find(aVoter.gender);
			it1->second++;
		}
	}
}