#include <iostream>
#include <string>
#include "Results.h"
#include "Voter.h"

int MainMenu(Results aResults);
void CollectorsMenu(Results aResults);
void VotersMenu(Results aResults);

int main()
{
	Results aResults(0, 0);
	MainMenu(aResults);
}

int MainMenu(Results aResults)
{
	std::cout << "Choose an option:" << std::endl;
	std::cout << "1. I'm a voter!" << std::endl;
	std::cout << "2. I'm a collector!" << std::endl;
	std::cout << "3. End!" << std::endl;
	int option;
	std::cin >> option;
	switch (option)
	{
	case 1: VotersMenu(aResults); break;
	case 2:
	{
		std::cin.ignore();
		std::cout << "Enter password: ";
		std::string collectorsPassword;
		std::getline(std::cin, collectorsPassword);
		if (collectorsPassword == "12344321")
		{
			CollectorsMenu(aResults);
		}
		else
		{
			std::cout << "Wrong password! Lets start again!" << std::endl;
			MainMenu(aResults);
		}
	}
		break;
	case 3: return 0; break;
	default: std::cout << "Wrong choice! Try again!" << std::endl;
		MainMenu(aResults);
	}
}

void CollectorsMenu(Results aResults)
{	
	if (aResults.votesForStay == 0 && aResults.votesForLeave == 0)
	{
		std::cout << "Noone has voted yet!" << std::endl;
		MainMenu(aResults);
	}
	else
	{
		std::cout << "Choose an option:" << std::endl;
		std::cout << "1. Results in percents" << std::endl;
		std::cout << "2. Results in number" << std::endl;
		std::cout << "3. Results based on Age" << std::endl;
		std::cout << "4. Results based on Name" << std::endl;
		std::cout << "5. Results based on Ethnos" << std::endl;
		std::cout << "6. Results based on Living citi/village" << std::endl;
		std::cout << "7. Main menu" << std::endl;
		int option;
		std::cin >> option;
		switch (option)
		{
		case 1: aResults.resultsInPercent(aResults.votesForStay, aResults.votesForLeave); break;
		case 2: aResults.resultsInNumbers(aResults.votesForStay, aResults.votesForLeave); break;
		case 3:
		{
			std::cout << "Enter age: ";
			int anAge;
			std::cin >> anAge;
			aResults.resultsByAge(anAge);
		}
		break;

		case 4:
		{
			std::cin.ignore();
			std::cout << "Enter name: ";
			std::string aName;
			getline(std::cin, aName);
			aResults.resultsByName(aName);
		}
		break;

		case 5:
		{
			std::cin.ignore();
			std::cout << "Enter ethnos: ";
			std::string anEthnos;
			getline(std::cin, anEthnos);
			aResults.resultsByEthnos(anEthnos);
		}
		break;

		case 6:
		{
			std::cin.ignore();
			std::cout << "Enter city/village: ";
			std::string aCity;
			getline(std::cin, aCity);
			aResults.resultsByCity(aCity);
		}
		break;

		case 7: MainMenu(aResults); break;

		default: std::cout << "Wrong choice! Try again!" << std::endl;
			CollectorsMenu(aResults);
		}

		char anotherCheck;
		std::cout << "Do you want to check another result? (y - Yes, n - No):";
		std::cin >> anotherCheck;

		if (anotherCheck == 'y')
			CollectorsMenu(aResults);
		else
			MainMenu(aResults);
	}
}

void VotersMenu(Results aResults)
{
	std::cout << "Enter your age: ";
	int anAge;
	std::cin >> anAge;

	std::cin.ignore();

	std::cout << "Enter your name: ";
	std::string aName;
	getline(std::cin, aName);

	std::cout << "Enter your gender (m - male, f - female): ";
	char aGender;
	std::cin >> aGender;

	std::cin.ignore();

	std::cout << "Enter your city/village: ";
	std::string aCity;
	getline(std::cin, aCity);

	std::cout << "Enter your ethnos: ";
	std::string anEthnos;
	getline(std::cin, anEthnos);

	std::cout << "Enter your vote (1 - stay, 0 - leave): ";
	int aVote;
	std::cin >> aVote;
	std::auto_ptr<Voter> aVoter(new Voter(aName, anAge, aGender, aCity, anEthnos, aVote));

	std::cin.ignore();
	
	aResults.addVotes(*aVoter);

	MainMenu(aResults);
}