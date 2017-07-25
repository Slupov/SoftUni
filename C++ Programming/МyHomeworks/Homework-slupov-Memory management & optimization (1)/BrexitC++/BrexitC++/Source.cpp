//NOTE: the input data comes from a randomized database 
//held in a .txt file in the project's directory
#include <iostream>
#include <fstream>
#include <string>
#include <vector>
#include "Functions.h"
#define __VOTECOLLECTORPASSWORD "12344321"

using namespace std;

string global_tokens[6];
int global_tokens_size = sizeof(global_tokens) / sizeof(global_tokens[0]);

void getTokens(string line)
{
	int found, i = 0;
	while (line != "\0")
	{
		found = line.find("\t");

		if (found == -1)
		{
			found = line.length();
		}

		for (int f = 0; f < found; f++)
		{
			global_tokens[i] += line[f];
		}
		line.erase(0, found + 1);
		i++;
	}

	//print the token
	//for (int d = 0; d < i; d++)
	//{
	//	cout << global_tokens[d] << endl;
	//}
}

int main()
{
	string line;
	ifstream file("data.txt");

	vector<Voter> voters;

	if (file.is_open())
	{
		//gets every single line from the input txt file 
		//and splits it into tokens age,name,ethnos,etc.
		//then assigns them to a Voter object
		while (getline(file, line))
		{
			//cout << line << endl;
			getTokens(line);

			Voter newVoter;
			newVoter.setAge(atoi(global_tokens[0].c_str()));
			newVoter.setName(global_tokens[1]);
			newVoter.setGender(global_tokens[2]);
			newVoter.setCity(global_tokens[3]);
			newVoter.setEthnos(global_tokens[4]);
			newVoter.setVote(global_tokens[5]);

			//add the current voter to the vector holding all of them
			voters.push_back(newVoter);

			//reseting the tokens
			for (int i = 0; i < global_tokens_size; i++)
			{
				global_tokens[i] = "";
			}
		}

		file.close();
	}
	else
	{
		cout << "File is not open" << endl;
	}

	cout << "Please enter the correct password to see the vote collector menu : ";
	string password;
	cin >> password;

	while (password != __VOTECOLLECTORPASSWORD)
	{
		cout << "Wrong password, please try again:";
		cin >> password;
	}

	printMenu();

	int choice;
	bool invalidInput = true;
	while (invalidInput == true)
	{
		while (true)
		{
			cout << endl;
			cout << "ENTER YOUR CHOICE: ";
			cin >> choice;
			if (choice == -858993460)
			{
				cout << "FATAL ERROR! Cannot input string !!!" << endl;
				return 0;
			}
			if (choice >= 1 && choice <= 6)
			{
				invalidInput = false;
			}
			cout << "-------------------" << endl;
			switch (choice)
			{
			case 1:resultInPercent(voters); break;
			case 2:resultInNumbers(voters); break;
			case 3:resultOnAge(voters); break;
			case 4:resultOnFirstName(voters); break;
			case 5:resultOnEthnos(voters); break;
			case 6:resultOnLivingCity(voters); break;
			case 7:resultAllNames(voters); break;
			case 8:return 0;
			default:
				cout << "Wrong input! No such option in the menu. Try again" << endl;
				break;
			}


		}

	}

	return 0;
}
