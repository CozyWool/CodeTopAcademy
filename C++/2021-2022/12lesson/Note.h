#pragma once
#include <iostream>
using namespace std;
class Note
{
private:
	string name;
	string lastName;
	int dateBirthday[3];
public:
	Note()
	{

	}
	Note(string name, string lastName, int day, int month, int year) :
		name(name), lastName(lastName), dateBirthday{ day, month, year }
	{

	}
	void Set(string name, string lastName, int day, int month, int year)
	{
		this->name = name;
		this->lastName = lastName;
		dateBirthday[0] = day;
		dateBirthday[1] = month;
		dateBirthday[2] = year;
	}
	void SetOnKeyboard()
	{
		cout << "Write a person's name: ";
		cin >> name;
		cout << "Write a person's last name: ";
		cin >> lastName;
		cout << "Write person's birthday: ";
		cin >> dateBirthday[0] >> dateBirthday[1] >> dateBirthday[2];
	}
	void Print()
	{
		cout << "Person's name: " << name << endl;
		cout << "Person's last name: " << lastName << endl;
		cout << "Person's birthday:" << dateBirthday[0] << "." << dateBirthday[1] << "." << dateBirthday[2] << endl;
		cout << "\n-------------------------\n" << endl;
	}
	friend void FindAMonth(Note* notes, size_t size, int month);
};

