#include <iostream>
#include <Windows.h>
#include <cctype>
#include <string>
#include <algorithm>
#pragma warning(disable : 4996)
using namespace std;

int mystrcmp(const char* str1, const char* str2)
{
	return strcmp(str1, str2);
}

int StringToNumber(const char* str)
{
	return atoi(str);
}

string NumberToString(int number)
{
	return to_string(number);
}

char* Uppercase(char* str1)
{
	return strupr(str1);
}

char* Lowercase(char* str1)
{
	return strlwr(str1);
}

char* mystrrev(char* str)
{
	return strrev(str);
}

int main()
{
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);

	cout << "Строки\nДомашнее задание №2\n";

	int cmd;
	int result = 0;
	int number;
	string str;
	string str2;
	char* ptrarr = nullptr;
	while (true)
	{
		cout << "Введите номер задания от 1 до 6:";
		cin >> cmd;
		cin.seekg(cin.eof());
		switch (cmd)
		{
		case 1:
			cout << "Введите первую строку:";
			getline(cin, str);
			cout << "Введите вторую строку:";
			getline(cin, str2);

			result = mystrcmp(str.c_str(), str2.c_str());

			cout << "Результат:";

			switch (result)
			{
			case 0:
				cout << "строки равны" << endl;
				break;
			case 1:
				cout << "первая строка больше второй" << endl;
				break;
			case -1:
				cout << "вторая строка больше второй" << endl;
				break;
			default:
				break;
			}
			break;
		case 2:
			cout << "Введите строку:";
			getline(cin, str);

			result = StringToNumber(str.c_str());

			cout << "Ваше новое число:" << result << endl;
			break;
		case 3:
			cout << "Введите число:";
			cin >> number;
			cin.seekg(cin.eof());

			str = NumberToString(number);

			cout << "Ваша новая строка:" << str << endl;
			break;
		case 4:
			cout << "Введите строку:";
			getline(cin, str);
			copy(str.begin(), str.end(), ptrarr);
			str = Uppercase(ptrarr);

			cout << "Ваша новая строка:" << str << endl;
			ptrarr = nullptr;
			break;
		case 5:
			cout << "Введите строку:";
			getline(cin, str);
			copy(str.begin(), str.end(), ptrarr);
			str = Lowercase(ptrarr);

			cout << "Ваша новая строка:" << str << endl;
			ptrarr = nullptr;
			break;
		case 6:													 
			cout << "Введите строку:";							 
			getline(cin, str);									 
			copy(str.begin(), str.end(), ptrarr);				 
			str = mystrrev(ptrarr);								 
																 
			cout << "Ваша новая строка:" << str << endl;	
			ptrarr = nullptr;
			break;												 
		default:												 
			cout << "Нет такого задания!" << endl;				 
			break;												 
		}														 
	}															 
	delete[] ptrarr;											 
}
