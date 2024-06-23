#include <iostream>
#include <conio.h>
#include <math.h>
#include <stdio.h>
using namespace std;

int main()
{
	setlocale(LC_ALL, "Russian");
	
	int sum = 0;

	
	for (int i = 0; i < 5; i++)
	{
		int value;
		cout << "Input number: ";
	
		cin >> value;

		if (value % 2 == 1)
			continue;

		sum += value;
	}
	cout << "Sum all odd numbers equal " << sum << endl;
	/*
	int a, b;
	cout << "Введите ширину:";
	cin >> a;
	cout << "Введите длину:";
	cin >> b;
	
	for (int i = 0; i < a; i++)
	{
		for (int j = 0; j < b; j++)
		{
			if (i >= j && i + j >= b - 1)
				cout << "|===|";
			else
				cout << "     ";
		}
		cout << endl;
	}
	for (int i = 0; i < a; i++)
	{
		for (int j = 0; j < b; j++)
			cout << "|###|";
		cout << endl;
	}
	cout << endl;
	*/
	/*
	for (int i = 0; i < 7; i++)
	{
		for (int j = 0; j < 7; j++)
		{
			//if (i == j || i + j == 4) // главная и побочная диагональ
			//if (i < j || i > j) // области под и над главной диагональю
			//if (i + j < 4 || i + j > 4) // области под и над побочной диагональю
			if (i == j || i + j == 6)
				cout << "* ";
			else
				cout << "0 ";
		}
		cout << endl;
	}
	*/
}
