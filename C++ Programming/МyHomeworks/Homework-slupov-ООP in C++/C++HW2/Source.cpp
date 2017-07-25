#include<iostream>
#include<string>

using namespace std;

class Building
{
private:
	int _floors;
	int _offices;
	int _employees;
	int _freeWorkingSeats;
	double coefficient;     //(double)getEmployees() / ((double)getEmployees() + (double)getFreeWorkingSeats());
	double peoplePerFloor;  //(double)getEmployees() / (double)getFloors(); //////////////////
	double officesPerFloor; //(double)getOffices() / (double)getFloors();
	double peoplePerOffice; //(double)getEmployees() / (double)getOffices();

public:
	string _name;
	Building();
	~Building();

	int getFloors();
	int getOffices();
	int getEmployees();
	int getFreeWorkingSeats();

	double getCoefficient();
	double getPeoplePerFloor();
	double getOfficesPerFloor();
	double getPeoplePerOffice();

	void setFloors(int newFloors);
	void setOffices(int newOffices);
	void setEmployees(int newEmployees);
	void setFreeWorkingSeats(int newFreeWorkingSeats);

	void setCoefficient(double newCoefficient);
	void setPeoplePerFloor(double newPeoplePerFloor);
	void setOfficesPerFloor(double newOfficesPerFloor);
	void setPeoplePerOffice(double newPeoplePerOffice); 


};

Building::Building() { };
Building::~Building() { };

void Building::setFloors(int newFloors) { _floors = newFloors; }
void Building::setOffices(int newOffices) { _offices = newOffices; }
void Building::setEmployees(int newEmployees) { _employees = newEmployees; }
void Building::setFreeWorkingSeats(int newFreeWorkingSeats) { _freeWorkingSeats = newFreeWorkingSeats; }

void Building::setCoefficient(double newCoefficient) { coefficient = newCoefficient; }
void Building::setPeoplePerFloor(double newPeoplePerFloor) { peoplePerFloor = newPeoplePerFloor; }
void Building::setOfficesPerFloor(double newOfficesPerFloor) { officesPerFloor = newOfficesPerFloor; }
void Building::setPeoplePerOffice(double newPeoplePerOffice) { peoplePerOffice = newPeoplePerOffice; }


int Building::getFloors() { return _floors; }
int Building::getOffices() { return _offices; }
int Building::getEmployees() { return _employees; }
int Building::getFreeWorkingSeats() { return _freeWorkingSeats; }

double Building::getCoefficient() {return coefficient;}
double Building::getPeoplePerFloor() {return peoplePerFloor;}
double Building::getOfficesPerFloor () {return officesPerFloor;}
double Building::getPeoplePerOffice () {return peoplePerFloor;}


void Swap(double array1[], int index1, int index2)
{
	double temp = array1[index2];
	array1[index2] = array1[index1];
	array1[index1] = temp;
}

int main()
{
	Building XYZindustries = Building();
	XYZindustries._name = "XYZ industries";
	XYZindustries.setFloors(6);
	XYZindustries.setOffices(127);
	XYZindustries.setEmployees(600);
	XYZindustries.setFreeWorkingSeats(196);

	XYZindustries.setCoefficient((double)XYZindustries.getEmployees() / ((double)XYZindustries.getEmployees() + (double)XYZindustries.getFreeWorkingSeats()));
	XYZindustries.setPeoplePerFloor((double)XYZindustries.getEmployees() / (double)XYZindustries.getFloors());
	XYZindustries.setOfficesPerFloor((double)XYZindustries.getOffices() / (double)XYZindustries.getFloors());
	XYZindustries.setPeoplePerOffice((double)XYZindustries.getEmployees() / (double)XYZindustries.getOffices()); // wrong output

	Building RapidDevelopmentCrew = Building();
	RapidDevelopmentCrew._name = "Rapid Development Crew";
	RapidDevelopmentCrew.setFloors(7); //RESTAURANT ON THE FIRST FLOOR!
	RapidDevelopmentCrew.setOffices(210);
	RapidDevelopmentCrew.setEmployees(822);
	RapidDevelopmentCrew.setFreeWorkingSeats(85);

	RapidDevelopmentCrew.setCoefficient((double)RapidDevelopmentCrew.getEmployees() / ((double)RapidDevelopmentCrew.getEmployees() + (double)RapidDevelopmentCrew.getFreeWorkingSeats()));
	RapidDevelopmentCrew.setPeoplePerFloor((double)RapidDevelopmentCrew.getEmployees() / (double)RapidDevelopmentCrew.getFloors());
	RapidDevelopmentCrew.setOfficesPerFloor((double)RapidDevelopmentCrew.getOffices() / (double)RapidDevelopmentCrew.getFloors());
	RapidDevelopmentCrew.setPeoplePerOffice((double)RapidDevelopmentCrew.getEmployees() / (double)RapidDevelopmentCrew.getOffices());


	Building SoftUni = Building();
	SoftUni._name = "Software University";
	SoftUni.setFloors(11);
	SoftUni.setOffices(106);
	SoftUni.setEmployees(200);
	SoftUni.setFreeWorkingSeats(60);

	SoftUni.setCoefficient((double)SoftUni.getEmployees() / ((double)SoftUni.getEmployees() + (double)SoftUni.getFreeWorkingSeats()));
	SoftUni.setPeoplePerFloor((double)SoftUni.getEmployees() / (double)SoftUni.getFloors());
	SoftUni.setOfficesPerFloor((double)SoftUni.getOffices() / (double)SoftUni.getFloors());
	SoftUni.setPeoplePerOffice((double)SoftUni.getEmployees() / (double)SoftUni.getOffices());

	Building businessPark[] = { XYZindustries, RapidDevelopmentCrew, SoftUni };

	//please leave a comment on my homework if you know a better/faster way of printing most employees, free places etc. (function with a parameter pointer to a class member funciton?)

	double buildingsEmployees[] = { (double)XYZindustries.getEmployees(), (double)RapidDevelopmentCrew.getEmployees(), (double)SoftUni.getEmployees() };
	double buildingsFreeSeats[] = { (double)XYZindustries.getFreeWorkingSeats(), (double)RapidDevelopmentCrew.getFreeWorkingSeats(), (double)SoftUni.getFreeWorkingSeats() };
	double buildingsCoefficients[] = { XYZindustries.getCoefficient(), RapidDevelopmentCrew.getCoefficient(), SoftUni.getCoefficient() };
	double buildingsPPF[] = { XYZindustries.getPeoplePerFloor(), RapidDevelopmentCrew.getPeoplePerFloor(), SoftUni.getPeoplePerFloor() };
	double buildingsOPF[] = { XYZindustries.getOfficesPerFloor(), RapidDevelopmentCrew.getOfficesPerFloor(), SoftUni.getOfficesPerFloor() };
	double buildingsPPO[] = { XYZindustries.getPeoplePerOffice(), RapidDevelopmentCrew.getPeoplePerOffice(), SoftUni.getPeoplePerOffice() };

#pragma region AscendingSort

	for (int i = 0; i < 3; i++)
	{
		for (int j = i + 1; j < 3; j++)
		{
			if (buildingsEmployees[i] > buildingsEmployees[j])
			{
				Swap(buildingsEmployees, i, j);
			}
			if (buildingsFreeSeats[i] > buildingsFreeSeats[j])
			{
				Swap(buildingsFreeSeats, i, j);
			}
			if (buildingsCoefficients[i] > buildingsCoefficients[j])
			{
				Swap(buildingsCoefficients, i, j);
			}
			if (buildingsPPF[i] > buildingsPPF[j])
			{
				Swap(buildingsPPF, i, j);
			}
			if (buildingsOPF[i] > buildingsOPF[j])
			{
				Swap(buildingsOPF, i, j);
			}
			if (buildingsPPO[i] > buildingsPPO[j])
			{
				Swap(buildingsPPO, i, j);
			}
		}
	}
#pragma endregion

	//please leave a comment on my homework if you know a better/faster way of printing most employees, free places etc. (function with a parameter pointer to a class member funciton?)
#pragma region ConditionalPrints


#pragma region MostEmployeesChecker
	if (buildingsEmployees[2] == XYZindustries.getEmployees())
	{
		cout << "Most employees -> " << XYZindustries._name << " -> " << buildingsEmployees[2] << endl;
	}
	else if (buildingsEmployees[2] == RapidDevelopmentCrew.getEmployees())
	{
		cout << "Most employees -> " << RapidDevelopmentCrew._name << " -> " << buildingsEmployees[2] << endl;
	}
	else
	{
		cout << "Most employees -> " << SoftUni._name << " -> " << buildingsEmployees[2] << endl;
	}
#pragma endregion

#pragma region MostFreePlacesChecker
	if (buildingsFreeSeats[2] == XYZindustries.getFreeWorkingSeats())
	{
		cout << "Most free working seats -> " << XYZindustries._name << " -> " << buildingsFreeSeats[2] << endl;
	}
	else if (buildingsEmployees[2] == RapidDevelopmentCrew.getFreeWorkingSeats())
	{
		cout << "Most free working seats -> " << RapidDevelopmentCrew._name << " -> " << buildingsFreeSeats[2] << endl;
	}
	else
	{
		cout << "Most free working seats -> " << SoftUni._name << " -> " << buildingsFreeSeats[2] << endl;
	}
#pragma endregion

#pragma region HighestCoefficientChecker
	if (buildingsCoefficients[2] == XYZindustries.getCoefficient())
	{
		cout << "Highest coefficient  -> " << XYZindustries._name << " -> " << buildingsCoefficients[2] << endl;
	}
	else if (buildingsCoefficients[2] == RapidDevelopmentCrew.getCoefficient())
	{
		cout << "Highest coefficient  -> " << RapidDevelopmentCrew._name << " -> " << buildingsCoefficients[2] << endl;
	}
	else
	{
		cout << "Highest coefficient  -> " << SoftUni._name << " -> " << buildingsCoefficients[2] << endl;
	}
#pragma endregion

#pragma region MostPplPerFloorChecker
	if (buildingsPPF[2] == XYZindustries.getPeoplePerFloor())
	{
		cout << "Most people per floor  -> " << XYZindustries._name << " -> " << buildingsPPF[2] << endl;
	}
	else if (buildingsPPF[2] == RapidDevelopmentCrew.getPeoplePerFloor())
	{
		cout << "Most people per floor  -> " << RapidDevelopmentCrew._name << " -> " << buildingsPPF[2] << endl;
	}
	else
	{
		cout << "Most people per floor  -> " << SoftUni._name << " -> " << buildingsPPF[2] << endl;
	}
#pragma endregion

#pragma region LeastPplPerFloorChecker
	if (buildingsPPF[0] == XYZindustries.getPeoplePerFloor())
	{
		cout << "Least people per floor  -> " << XYZindustries._name << " -> " << buildingsPPF[0] << endl;
	}
	else if (buildingsPPF[0] == RapidDevelopmentCrew.getPeoplePerFloor())
	{
		cout << "Least people per floor  -> " << RapidDevelopmentCrew._name << " -> " << buildingsPPF[0] << endl;
	}
	else
	{
		cout << "Least people per floor  -> " << SoftUni._name << " -> " << buildingsPPF[0] << endl;
	}
#pragma endregion

#pragma region MostOfficesPerFloor
	if (buildingsOPF[2] == XYZindustries.getOfficesPerFloor())
	{
		cout << "Most offices per floor  -> " << XYZindustries._name << " -> " << buildingsOPF[2] << endl;
	}
	else if (buildingsOPF[2] == RapidDevelopmentCrew.getOfficesPerFloor())
	{
		cout << "Most offices per floor  -> " << RapidDevelopmentCrew._name << " -> " << buildingsOPF[2] << endl;
	}
	else
	{
		cout << "Most offices per floor  -> " << SoftUni._name << " -> " << buildingsOPF[2] << endl;
	}
#pragma endregion

#pragma region LeastOfficesPerFloor
	if (buildingsOPF[0] == XYZindustries.getOfficesPerFloor())
	{
		cout << "Least offices per floor  -> " << XYZindustries._name << " -> " << buildingsOPF[0] << endl;
	}
	else if (buildingsOPF[0] == RapidDevelopmentCrew.getOfficesPerFloor())
	{
		cout << "Least offices per floor  -> " << RapidDevelopmentCrew._name << " -> " << buildingsOPF[0] << endl;
	}
	else
	{
		cout << "Least offices per floor  -> " << SoftUni._name << " -> " << buildingsOPF[0] << endl;
	}
#pragma endregion

#pragma region MostPplPerOffice
	if (buildingsPPO[2] == XYZindustries.getPeoplePerOffice())
	{
		cout << "Most offices per floor  -> " << XYZindustries._name << " -> " << buildingsPPO[2] << endl;
	}
	else if (buildingsPPO[2] == RapidDevelopmentCrew.getPeoplePerOffice())
	{
		cout << "Most offices per floor  -> " << RapidDevelopmentCrew._name << " -> " << buildingsPPO[2] << endl;
	}
	else
	{
		cout << "Most offices per floor  -> " << SoftUni._name << " -> " << buildingsPPO[2] << endl;
	}
#pragma endregion

#pragma region LeastPplPerOffice
	if (buildingsPPO[0] == XYZindustries.getPeoplePerOffice())
	{
		cout << "Least offices per floor  -> " << XYZindustries._name << " -> " << buildingsPPO[0] << endl;
	}
	else if (buildingsPPO[0] == RapidDevelopmentCrew.getPeoplePerOffice())
	{
		cout << "Least offices per floor  -> " << RapidDevelopmentCrew._name << " -> " << buildingsPPO[0] << endl;
	}
	else
	{
		cout << "Least offices per floor  -> " << SoftUni._name << " -> " << buildingsPPO[0] << endl;
	}
#pragma endregion

#pragma endregion

system("pause");
}




