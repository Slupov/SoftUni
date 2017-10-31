#include <iostream>
#include <vector>
#include <string>

using namespace std;

int main()
{
	char ch = ' ';
	vector<char> aVector;
	while (ch != '.')
	{
		cin >> ch;
		aVector.push_back(ch);
	}
	for (int i = aVector.size()-2; i >= 0 ; i--)
	{
		if (i%2 == 0)
		{
			cout << (char)((char)aVector[i] + 3);
		}
		else if (i%2!=0)
		{
			cout << (char)((char)aVector[i] - 3);
		}
	}

	return 0;
}