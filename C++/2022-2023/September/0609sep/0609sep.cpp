#include <iostream>
#include <cstring>
#include <string>
#include <cstdio>
#include <conio.h>
#include <Windows.h>

using namespace std;

int main()
{
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);
	
	char str[] = "Hello world!";
	char* ptrstr = str;
	char symbol = '!';

	
	char* str2 = strrchr(ptrstr, symbol);
	
	cout << str2 << endl;
	if (str2 != NULL)
	{
		cout << "Такой символ есть!" << endl;
	}
	else
	{
		cout << "Нет такого символа!" << endl;
	}

}