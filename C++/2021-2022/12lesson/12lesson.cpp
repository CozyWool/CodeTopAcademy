#include <iostream>
#include <stdlib.h>
#include "Route.h"
#include "Note.h"
#include "Student.h"
using namespace std;
void FindANumber(Route* routes, size_t size, int n)
{
	bool isFound = false;
	for (int i = 0; i < size; i++)
		if (routes[i].number == n)
		{
			isFound = true;
			cout << "Route found\n" << endl;
			routes[i].Print();
			continue;
		}
	if (isFound)
		return;
	cout << "Route didn't find" << endl;
}
void FindAMonth(Note* notes, size_t size, int month)
{
	bool isFound = false;
	for (int i = 0; i < size; i++)
		if (notes[i].dateBirthday[1] == month)
		{
			isFound = true;
			cout << "Month found\n" << endl;
			notes[i].Print();
			continue;
		}
	if (isFound)
		return;
	cout << "Month didn't find" << endl;
}
void FindAStudent(Student* students, size_t size)
{
	bool isFound = false;
	for (int i = 0; i < size; i++)
	{
		double avrGrade = students[i].CalcAvrGrade();
		if (avrGrade >= 4 && avrGrade <= 5)
		{
			isFound = true;
			cout << "Student found\n" << endl;
			students[i].Print();
			continue;
		}
	}
	if (isFound)
		return;
	cout << "Students not found" << endl;
}
int main()
{
	setlocale(0, "");
	size_t size = 5;
	/*Route* r = new Route[size];
	r[0].Set("Moscow", "Saint-Petersburg", 1121);
	r[1].Set("Toronto", "Moscow", 1187);
	r[2].Set("Washington", "Vena", 1222);
	r[3].Set("Kiev", "Tyumen", 1010);
	r[4].Set("Vladivostok", "Moscow", 1120);

	for (int i = 0; i < size; i++)
		r[i].Print();
	int number = 1120;
	cout << "Write number of route: ";
	cin >> number;
	cout << endl;
	FindANumber(r, size, number);
	delete[] r;
	system("CLS");

	Note* note = new Note[size];
	note[0].Set("Иван", "Иванов", 1, 1, 1998);
	note[1].Set("Глеб", "Глебов", 18, 6, 2000);
	note[2].Set("Кирилл", "Лобанов", 9, 5, 2001);
	note[3].Set("Сёмен", "Просов", 1, 1, 2010);
	note[4].Set("Никита", "Ильич", 1, 1, 1970);
	for (int i = 0; i < size; i++)
		note[i].Print();
	int m;
	cout << "Write person's month: ";
	cin >> m;
	FindAMonth(note, size, m);
	delete[] note;
	system("CLS");*/
	Student* student = new Student[size];
	/*student[0].Set("Иванов", "И.И", "БСР-1", 4, 5, 5, 4, 5); // чтобы не вводить в ручную(долго :\)
	student[1].Set("Глебов", "Г.Г", "ТЕХ-2", 3, 2, 4, 3, 4);
	student[2].Set("Лобанов", "К.К.", "МЕД-3", 2, 3, 3, 3, 3);
	student[3].Set("Просов", "С.С.", "ЗОО-4", 5, 5, 5, 5, 5);
	student[4].Set("Ильич", "Н.Н.", "АГРО-5", 4, 4, 4, 4, 4);*/
	student[0].SetOnKeyboard();
	student[1].SetOnKeyboard();
	student[2].SetOnKeyboard();
	student[3].SetOnKeyboard();
	student[4].SetOnKeyboard();
	for (int i = 0; i < size; i++)
		student[i].Print();
	cout << "Поиск студентов-ударников\n" << endl;
	FindAStudent(student, size);
	delete[] student;
}
