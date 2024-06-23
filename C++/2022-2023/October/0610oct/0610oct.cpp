#include <iostream>
#include <Windows.h>
#include <math.h>
#include <string>
#include "array.h"
#include <stdio.h>

using namespace std;

int main()
{
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);
	
	int n;
	cout << "Введите число:";
	cin >> n;
	cout << "Сумма цифр:" << (n / 100 + n / 10 % 10 + n % 10) << endl;
	/*#line 1000 "math.h"
	cout << __FILE__ << endl << __LINE__ << endl;


	#line 17
	cout << "Наши значения: " << __FILE__ << endl << __LINE__ << endl;*/
	/*int n;

	cout << "Введите число шариков:";
	cin >> n;
	cout << ((n > 2 && n != 4 && n != 7) ? "Да" : "Нет") << endl;*/
}