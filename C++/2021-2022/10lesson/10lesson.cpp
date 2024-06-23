#include <clocale>
#include <stdlib.h>
#include <ctime>
#include <iostream>
#include <string>
#include "Calc.h"
using namespace std;

int main()
{
	setlocale(0, "");
	srand(time(NULL));
	Calc c;
	// cout << c.BirthdayCalc() << endl;
	double* arr;
	int size;
	cin >> size;
	arr = new double[size];
	for (int i = 0; i < size; i++)
		cin >> arr[i];
	cout << endl;
	for (int i = 0; i < size; i++)
		cout << arr[i] << " ";
	cout << "\n\n";
	cout << c.Calculate(arr, size, '*');
	/*
	int year;
	int month;
	while (true)
	{
		cin >> year >> month;
		if (month < 1)
		{
			cout << "Ошибка" << endl;
			continue;
		}
		if (month == January)
		{
			cout << "В январе " << year << " года 31 день" << endl;
		}
		if (month == February)
		{
			cout << "В феврале " << year << " года " << (((year % 4 == 0 && year % 100 != 0) || year % 400 == 0) ? "29" : "28") << " дней" << endl;
		}
		if (month == March)
		{
			cout << "В марте " << year << " года 31 день" << endl;
		}
		if (month == April)
		{
			cout << "В апреле " << year << " года 30 дней" << endl;
		}
		if (month == May)
		{
			cout << "В мае " << year << " года 31 день" << endl;
		}
		if (month == June)
		{
			cout << "В июне " << year << " года 30 дней" << endl;
		}
		if (month == July)
		{
			cout << "В июле " << year << " года 31 день" << endl;
		}
		if (month == August)
		{
			cout << "В августе " << year << " года 31 день" << endl;
		}
		if (month == September)
		{
			cout << "В сентябре " << year << " года 30 дней" << endl;
		}
		if (month == October)
		{
			cout << "В октябре " << year << " года 31 день" << endl;
		}
		if (month == November)
		{
			cout << "В ноябре " << year << " года 30 дней" << endl;
		}
		if (month == December)
		{
			cout << "В декабре " << year << " года 31 день" << endl;
		}
	}
	*/
	/*const int n = 10; сортировка выбором
	int arr[n] = { 1, 25, 6, 32, 43, 5, 96, 23, 4, 55 };
	int min = arr[0];
	int buff = 0;
	for (int i = 0; i < n; i++)
	{
		min = i;
		for (int j = i + 1; j < n; j++)
			min = (arr[j] < arr[min]) ? j : min;
		if (i != min)
		{
			buff = arr[i];	
			arr[i] = arr[min];
			arr[min] = buff;
		}
	}
	for (int i = 0; i < n; i++)
	{
		cout << arr[i] << " ";
	}*/
}
