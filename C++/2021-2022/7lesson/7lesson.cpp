#include <ctime>
#include <iostream>
#include <stdlib.h>
#include <clocale>
using namespace std;

bool znak(int a)
{
	return a > 0 ? true : false;
}

int main()
{
	setlocale(LC_ALL, "russian");
	srand(time(NULL));
	int a; 
	cout << "Введите a:";
	cin >> a;
	if (a==0)
	{
		cout << "a = 0";
		return 0;
	}
	cout << "Результат функции:" << znak(a) << endl;
}