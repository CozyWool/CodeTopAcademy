#pragma once
#include <iostream>
using namespace std;
class Student
{
	
private:
	string surname;
	string initials;
	string groupNumber;
	double grades[5];
public:
	Student()
	{

	}
	Student(string surname, string initials, string groupNumber, double math, double eng, double rus, double PE, double IT) :
		surname(surname), initials(initials), groupNumber(groupNumber), grades{ math,eng,rus,PE,IT } 
	{

	}
	void Set(string surname, string initials, string groupNumber, double math, double eng, double rus, double PE, double IT)
	{
		this->surname = surname;
		this->initials = initials;
		this->groupNumber = groupNumber;
		grades[0] = math;
		grades[1] = eng;
		grades[2] = rus;
		grades[3] = PE;
		grades[4] = IT;
	}
	void SetOnKeyboard()
	{
		cout << "Write a student's surname: ";
		cin >> surname;
		cout << "Write a student's initials: ";
		cin >> initials;
		cout << "Write a student's group number: ";
		cin >> groupNumber;
		cout << "Write student's grades for math,eng,rus,PE and IT: ";
		cin >> grades[0] >> grades[1] >> grades[2] >> grades[3] >> grades[4];
		cout << "\n----------------------------------\n" << endl;
	}
	void Print()
	{
		cout << "Student's surname: " << surname << endl;
		cout << "Student's group number: " << groupNumber << endl;
		cout << "\n----------------------------------\n" << endl;
	}
	double CalcAvrGrade()
	{
		double sum = 0;
		for (int i = 0; i < 5; i++)
			sum += grades[i];
		return sum / 5;
	}
	friend void FindAStudent(Student* students, size_t size);
};

