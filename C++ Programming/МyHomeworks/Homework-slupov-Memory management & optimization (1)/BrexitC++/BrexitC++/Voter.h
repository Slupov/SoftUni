#include <iostream>
#include <string>
using namespace std;

class Voter
{
private:
	int age;
	string name;
	string gender;
	string city;
	string ethnos;
	string vote;
public:
	void setAge(int newAge) { this->age = newAge; }
	void setName(string newName) { this->name = newName; }
	void setGender(string newGender) { this->gender = newGender; }
	void setCity(string newCity) { this->city = newCity; }
	void setEthnos(string newEthnos) { this->ethnos = newEthnos; }
	void setVote(string newVote) { this->vote = newVote; }

	int getAge() { return this->age; };
	string getName() { return this->name; };
	string getGender() { return this->gender; };
	string getCity() { return this->city; };
	string getEthnos() { return this->ethnos; };
	string getVote() { return this->vote; };

	Voter()
	{
	}
};