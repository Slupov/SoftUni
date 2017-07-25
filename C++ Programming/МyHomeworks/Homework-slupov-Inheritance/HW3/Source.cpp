#include <iostream>
#include <string>
#include <vector>
#include <sstream>
#include <cstdlib>
#include <thread>

using namespace std;

class Course
{
public:
	string name;
	double studentsPoints;
	double courseSalary;
	Course() {};
};

class SoftuniPerson
{
public:
	string Id;
	string name;
	Course currentCourse;

};

class Student :public SoftuniPerson
{
public:
	double averageMark;
	//getters
	double getAverageMark() { return averageMark; }


};

class GuestTeacher : public SoftuniPerson
{
public:

};

class Teacher : public SoftuniPerson
{
public:
	int daysPassed;
	double monthlySalary;
};

Student readStudent()
{
	Student nextStudent;
	cout << "Please enter the given properties: " << endl;
	cout << "Student's ID: "; cin >> nextStudent.Id;
	cout << "Student's name: "; cin >> nextStudent.name;
	cout << "Student's current course: "; cin >> nextStudent.currentCourse.name;
	cout << "Student's current points for the course: "; cin >> nextStudent.currentCourse.studentsPoints;

	return nextStudent;

}

GuestTeacher readGuestTeacher()
{
	GuestTeacher nextGuestTeacher;

	cout << "Please enter the given properties: " << endl;
	cout << "Guest Teacher's ID: "; cin >> nextGuestTeacher.Id;
	cout << "Guest Teacher's name: "; cin >> nextGuestTeacher.name;
	cout << "Guest Teacher's current course: "; cin >> nextGuestTeacher.currentCourse.name;
	cout << "Guest Teacher's salary for the course: "; cin >> nextGuestTeacher.currentCourse.courseSalary; cout << endl;
	return nextGuestTeacher;
}

Teacher readTeacher()
{
	Teacher nextTeacher;
	cout << "Please enter the given properties: " << endl;
	cout << "Teacher's ID: "; cin >> nextTeacher.Id;
	cout << "Teacher's name: "; cin >> nextTeacher.name;
	cout << "Teacher's current course: "; cin >> nextTeacher.currentCourse.name;
	cout << "Teacher's monthly salary: "; cin >> nextTeacher.monthlySalary;
	return nextTeacher;
}

void programEndMessageAnimation()
{
	for (int i = 0; i < 3; i++)
	{
		cout << "\rClosing the program.  ";
		this_thread::sleep_for(0.2s);
		cout << "\rClosing the program..";
		this_thread::sleep_for(0.2s);
		cout << "\rClosing the program...";
		this_thread::sleep_for(0.2s);
	}

}

double averageEvaluationMark(int points)
{
	double result;
	result = ((double)points / 100.00) * 6;
	return result;
}

void getStudentData(string ID, vector<Student> students)
{
	for each (Student nextStudent in students)
	{
		if (nextStudent.Id == ID)
		{
			cout << nextStudent.name << "   ID: " << nextStudent.Id << endl;
			cout << "Current course: " << nextStudent.currentCourse.name << " with " << nextStudent.currentCourse.studentsPoints << endl;
			nextStudent.averageMark = averageEvaluationMark(nextStudent.currentCourse.studentsPoints);
			cout << "Average evaluaton mark: " << nextStudent.averageMark;
		}
	}
}

void getGuestTeacherData(string ID, vector<GuestTeacher> guestTeachers)
{
	for each (GuestTeacher guestTeacher in guestTeachers)
	{
		if (guestTeacher.Id == ID)
		{
			cout << guestTeacher.name << "   ID: " << guestTeacher.Id << endl;
			cout << "Current course: " << guestTeacher.currentCourse.name << " with salary " << guestTeacher.currentCourse.courseSalary << "leva" << endl;
		}
	}
}

void getTeacherData(string ID, vector<Teacher> teachers)
{
	for each (Teacher teacher in teachers)
	{
		if (teacher.Id == ID)
		{
			cout << teacher.name << "   ID: " << teacher.Id << endl;
			cout << "Current course: " << teacher.currentCourse.name << " with monthly salary " << teacher.monthlySalary << " leva" << endl;
		}
	}
}


int main()
{
	vector<Student> students;
	vector<Teacher> teachers;
	vector<GuestTeacher> guestTeachers;

#pragma region Menu

	cout << "                Please choose a number from the menu:" << endl;
	cout << "1. Get data for student with ID       | 2. Get data for teacher with ID" << endl;
	cout << "3. Get data for guest teacher with ID | 4. Add data for new student" << endl;
	cout << "5. Add data for new teacher           | 6. Add data for new guest teacher" << endl;
	cout << "NOTE: Type \"End\" to close the program" << endl;

	while (true)
	{
		string Text;
		cin >> Text;//string containing the number
		int choice;//number which will contain the result

		stringstream convert(Text); // stringstream used for the conversion initialized with the contents of Text
		convert >> choice;

		if (Text == "End")
		{
			choice = 7;
		}

		switch (choice)
		{
		case 1:
			if (students.empty())
			{
				cout << "There are currently no students available. Please add data." << endl;
				cout << "Sucessful operation! Choose another option or \"End\" :" << endl;
			}
			else
			{
				cout << "Type in the ID that belongs to the student you are searching for: ";
				string id;
				cin >> id;
				getStudentData(id, students);
				cout << endl;
				cout << "Sucessful operation! Choose another option or \"End\" :" << endl;
			} break;

		case 2:
			if (teachers.empty())
			{
				cout << "There are currently no teachers available. Please add data." << endl;
				cout << "Sucessful operation! Choose another option or \"End\" :" << endl;
			}
			else
			{
				cout << "Type in the ID that belongs to the teacher you are searching for: ";
				string id;
				cin >> id;
				getTeacherData(id, teachers);
				cout << endl;
				cout << "Sucessful operation! Choose another option or \"End\" :" << endl;
			} break;
		case 3:
			if (guestTeachers.empty())
			{
				cout << "There are currently no guest teachers available. Please add data." << endl;
				cout << "Sucessful operation! Choose another option or \"End\" :" << endl;
			}
			else
			{
				cout << "Type in the ID that belongs to the guest teacher you are searching for: ";
				string id;
				cin >> id;
				getGuestTeacherData(id, guestTeachers);
				cout << "Sucessful operation! Choose another option or \"End\" :" << endl;
			} break;
		case 4:
			students.push_back(readStudent());
			cout << "Sucessful operation! Choose another option or \"End\" :" << endl; break;
		case 5:
			teachers.push_back(readTeacher()); 
			cout << "Sucessful operation! Choose another option or \"End\" :" << endl; break;
		case 6:
			guestTeachers.push_back(readGuestTeacher());
			cout << "Sucessful operation! Choose another option or \"End\" :" << endl; break;
		case 7:
			programEndMessageAnimation(); return 1; break;
		default: cout << "Wrong input. Try again."<<endl; break;
		}

	}

#pragma endregion

	return 0;
}
