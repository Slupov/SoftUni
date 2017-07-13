//This program uses all the functions learned in lecture 1 ( printf , getline , sum , checker)
#include "stdafx.h"
#include <iostream>
#include <stdio.h>
#include <string>
using namespace std;

void printChar(char aCharacter)
{
	cout << "Print char function: " << aCharacter << endl;
}
int sum(int a, int b)
{
	return a + b;
}
string checkAge(unsigned short age)
{
	if (age > 1000)
	{
		return "Number is greater than 1000\n";
	}
	else if (age > 500)
	{
		return "Number is greater than 500\n";
	}
	else if (age > 0)
	{
		return "Number is positive\n";
	}
	else
	{
		return "Number is negative\n";
	}
}
int main()
{
	cout << "printf() function exercise:\n";
	float floatNumber = 3.141592141592;
	double doubleNumber = 3.141592141592;
	printf("%0.15f\n", floatNumber);
	printf("%0.15lf\n", doubleNumber); // 15 decimal places , more accurate
	cout << "----------------------------------\n";

	cout << "Other functions exercise:\n";
	printChar('a');

	cout << "Enter two integer numbers to check if their sum is greater than 1000, 500 or 0\n";
	int num1, num2;
	cin >> num1;
	cin >> num2;

	cout << checkAge(sum(num1, num2));
	cout << "-----------getline()---------------\n";
	cout << "Enter a string from the console:\n";

	string myString;
	getline(cin, myString);
	cout << "Your string is: " << "\"" << myString << "\"" << endl;

	return 0;
}


