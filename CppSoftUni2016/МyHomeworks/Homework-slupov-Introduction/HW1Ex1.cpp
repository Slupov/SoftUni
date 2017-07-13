#include "stdafx.h"
#include <iostream>
#include <string>
using namespace std;

int main()
{
	string myString;
	getline(cin, myString);
	cout << myString << endl;

	int upperCount = 0;
	int lowerCount = 0;
	int othersCount = 0;

	for each (char letter in myString)
	{
		if ((int)letter >= 65 && (int)letter <= 90)
		{
			upperCount++;
		}
		else if ((int)letter >= 97 && (int)letter <= 122)
		{
			lowerCount++;
		}
		else
		{
			othersCount++;
		}
	}

	cout << "There are [" << upperCount << "] upper case letters in the string" << endl;
	cout << "There are [" << lowerCount << "] lower case letters in the string" << endl;
	cout << "There are [" << othersCount << "] other characters in the string" << endl;

	return 0;
}


