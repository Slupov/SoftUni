#include <iostream>
#include <string>

using namespace std;

class Human
{
	public:
	int age;
	string name;

	Human()
	{
		cout << "New human created" << endl;
	}
	~Human()
	{
		cout << "Human has died" << endl;
	}

	//operator += predefinition
	Human& operator+=(const Human& other)
	{
		age += other.age;
		return *this;
	}
};

int main()
{
	Human aHuman;
	aHuman.age = 50;
	Human result;
	result.age = 16;

	result+=aHuman;
	printf("%d\n",result.age);
	
	return 0;
}