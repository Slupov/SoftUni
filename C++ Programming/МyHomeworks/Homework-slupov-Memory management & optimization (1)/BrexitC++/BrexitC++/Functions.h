#include <iostream>
#include <vector>
#include "Voter.h"
#include <map>
using namespace std;

void printMenu()
{
	system("cls"); //clears the console to present the menu
	cout << "|------------------------------MENU-------------------------------|" << endl;
	cout << "|1.Show result in %             |   5.Show result based on ethnos |" << endl;
	cout << "|2.Show result in numbers       |   6.Show result based on city   |" << endl;
	cout << "|3.Show result based on age     |   7.Show result based on nameS  |" << endl;
	cout << "|4.Show result based on name    |   8.END PROGRAM                 |" << endl;
	cout << "|-----------------------------------------------------------------|" << endl;
}


void resultInPercent(vector<Voter>& voters)
{
	long affirmative = 0;
	long negative = 0;
	double resultPercentage = 0.00;


	for each (Voter voter in voters)
	{
		if (voter.getVote() == "TRUE") affirmative++;
		else if (voter.getVote() == "FALSE") negative++;
	}

	resultPercentage = (affirmative / (double)voters.size())*100.00;

	cout << "FOR: " << resultPercentage << " %" << endl;
	cout << "Against: " << 100 - resultPercentage << " %" << endl;

}
void resultInNumbers(vector<Voter>& voters)
{
	long affirmative = 0;
	long negative = 0;
	double resultPercentage = 0.00;


	for each (Voter voter in voters)
	{
		if (voter.getVote() == "TRUE") affirmative++;
		else if (voter.getVote() == "FALSE") negative++;
	}

	cout << "FOR: " << affirmative << endl;
	cout << "Against: " << negative << endl;
}
void resultOnAge(vector<Voter>& voters)
{
	int wantedAge = 0;
	cout << "Enter an age to check the people's vote of that age: ";
	cin >> wantedAge;
	int affirmative = 0;
	int negative = 0;
	bool found = false;

	for each (Voter voter in voters)
	{
		if (voter.getAge() == wantedAge)
		{
			found = true;

			if (voter.getVote() == "TRUE")
			{
				affirmative++;
			}
			else if (voter.getVote() == "FALSE")
			{
				negative++;
			}
		}
	}

	if (found == false)
	{
		cout << "There are no voters with such age" << endl;
	}
	else cout << wantedAge << " y - " << affirmative << " Stay, " << negative << " Leave" << endl;

}
void resultOnFirstName(vector<Voter>& voters)
{
	string wantedFirstName = "";
	cout << "Enter a name to check the people's vote of that first name: ";
	cin >> wantedFirstName;
	int affirmative = 0;
	int negative = 0;

	for each (Voter voter in voters)
	{
		//extracting the first name by delimiter [space]
		//----------------------------------------------//
		string fullName = voter.getName();
		int found = fullName.find(" ");
		string firstName = "";
		for (int f = 0; f < found; f++)
		{
			firstName += fullName[f];
		}
		//----------------------------------------------//


		if (wantedFirstName == firstName)
		{
			if (voter.getVote() == "TRUE")
			{
				affirmative++;
			}
			else if (voter.getVote() == "FALSE")
			{
				negative++;
			}
		}
	}

	cout << "First Name: " << wantedFirstName << " - " << affirmative << " Stay, " << negative << " Leave" << endl;
}
void resultOnEthnos(vector<Voter>& voters)
{
	string wantedEthnos = "";
	cout << "Enter an ethnos to check the people's vote of that ethnos: ";
	cin >> wantedEthnos;
	int affirmative = 0;
	int negative = 0;

	for each (Voter voter in voters)
	{
		if (wantedEthnos == voter.getEthnos())
		{
			if (voter.getVote() == "TRUE")
			{
				affirmative++;
			}
			else if (voter.getVote() == "FALSE")
			{
				negative++;
			}
		}
	}

	cout << "Ethnos: " << wantedEthnos << " - " << affirmative << " Stay, " << negative << " Leave" << endl;
}
void resultOnLivingCity(vector<Voter>& voters)
{
	string wantedCity = "";
	cout << "Enter a living place to check the people's vote in that city/village: ";
	cin >> wantedCity;
	int affirmative = 0;
	int negative = 0;

	for each (Voter voter in voters)
	{
		if (wantedCity == voter.getCity())
		{
			if (voter.getVote() == "TRUE")
			{
				affirmative++;
			}
			else if (voter.getVote() == "FALSE")
			{
				negative++;
			}
		}
	}

	cout << "Living place: " << wantedCity << " - " << affirmative << " Stay, " << negative << " Leave" << endl;
}
void resultAllNames(vector<Voter>& voters)
{
	map<string, vector<int>> votesbyName;
	for each (Voter voter in voters)
	{
		//extracting the first name by delimiter [space]
		//----------------------------------------------//
		string fullName = voter.getName();
		int found = fullName.find(" ");
		string firstName = "";
		for (int f = 0; f < found; f++)
		{
			firstName += fullName[f];
		}
		//----------------------------------------------//

		if (votesbyName.find(firstName) == votesbyName.end()) {
			// key not found until now
			if (voter.getVote() == "TRUE")
			{
				//first affirmative vote 
				(votesbyName[firstName]).push_back(1);
				(votesbyName[firstName]).push_back(0);
			}
			else if (voter.getVote() == "FALSE")
			{
				//first negative vote 
				(votesbyName[firstName]).push_back(0);
				(votesbyName[firstName]).push_back(1);
			}
		}
		else {
			// key found
			if (voter.getVote() == "TRUE")
			{
				(votesbyName[firstName])[0]++;
			}
			else if (voter.getVote() == "FALSE")
			{
				(votesbyName[firstName])[1]++;
			}
		}
	}

	//printing every unique name and the votes for it
	for each (pair<string, vector<int>> pair in votesbyName)
	{
		cout << "Name: " << pair.first << " -> FOR:" << pair.second[0] << " AGAINST:" << pair.second[1] << endl;
	}
	
	
	cout << "----------------Enter a random key to continue----------------"<<endl;
	system("pause");
	printMenu();


}
