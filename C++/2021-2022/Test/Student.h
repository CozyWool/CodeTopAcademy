#pragma once
#include <iostream>
using namespace std;
class Student
{
private:
	string surname;
	string subject;
	int grade;
public:
	Student()
	{

	}
	Student(string surname, string subject, int grade)
	{
		this->surname = surname;
		this->subject = subject;
		this->grade = grade;
	}
	string getSurname()
	{
		return surname;
	}
	void setSurname(string s)
	{
		surname = s;
	}
	string getSubject()
	{
		return subject;
	}
	void setSubject(string s)
	{
		subject = s;
	}
	int getGrade() 
	{
		return grade;
	}
	void setGrade(int g)
	{
		grade = g;
	}
	void printInfo()
	{
		cout << "\tИнформация о студенте" << endl;
		cout << "Фамилия:" << surname << endl;
		cout << "Предмет:" << subject << endl;
		cout << "Оценка:" << grade << endl;
	}
};

